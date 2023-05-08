using System.Net;
using System.Security.Claims;
using API.DTOs.request;
using API.DTOs.response;
using API.Exceptions;
using API.Models;
using API.Repositories.Contracts;
using API.Utils;

namespace API.Services;

public class AuthService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly BcryptUtil _bcryptUtil;
    private readonly JwtUtil _jwtUtil;
    private readonly IConfiguration _config;

    public AuthService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository,
        IUniversityRepository universityRepository, IRoleRepository roleRepository,
        IAccountRoleRepository accountRoleRepository, IRefreshTokenRepository refreshTokenRepository, BcryptUtil bcryptUtil, JwtUtil jwtUtil, IConfiguration config)
    {
        (_accountRepository, _employeeRepository, _universityRepository, _roleRepository, _accountRoleRepository, _refreshTokenRepository,
            _bcryptUtil, _jwtUtil, _config) = (accountRepository,
            employeeRepository, universityRepository, roleRepository, accountRoleRepository, refreshTokenRepository, bcryptUtil, jwtUtil, config);
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        var foundEmployee = await _employeeRepository.FindOneByPk(request.Nik);
        if (foundEmployee is not null)
            throw new ApiException($"Nik '{request.Nik}' is already taken.")
                { Code = (int)HttpStatusCode.BadRequest };

        foundEmployee = await _employeeRepository.FindOneByEmailAsync(request.Email);
        if (foundEmployee is not null)
            throw new ApiException($"Email '{request.Email}' is already taken.")
                { Code = (int)HttpStatusCode.BadRequest };

        if (request.PhoneNumber != null)
        {
            foundEmployee = await _employeeRepository.FindOneByPhoneNumberAsync(request.PhoneNumber);
            if (foundEmployee is not null)
                throw new ApiException($"Phone Number '{request.PhoneNumber}' is already taken.")
                    { Code = (int)HttpStatusCode.BadRequest };
        }

        var account = request.ToEmployeeEntity();

        var foundUniversity = await _universityRepository.FindOneOrInsertByName(request.UniversityName);
        account.TbTrProfiling.Education.University = null;
        account.TbTrProfiling.Education.UniversityId = foundUniversity.Id;

        var foundRole = await _roleRepository.FindOneOrInsertByName("user");
        account.TbMAccount.TbTrAccountRoles.Add(new AccountRole
        {
            RoleId = foundRole.Id
        });

        account.HiringDate = DateTime.Now;
        account.TbMAccount.Password = _bcryptUtil.HashPassword(account.TbMAccount.Password);

        var registeredAccount = await _employeeRepository.InsertOne(account);
        if (registeredAccount is not null)
        {
            return new RegisterResponse
            {
                Email = registeredAccount.Email
            };
        }

        throw new ApiException($"Failed to register.") { Code = (int)HttpStatusCode.InternalServerError };
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var foundEmployee = await _employeeRepository.FindOneByEmailAsync(request.Email);
        if (foundEmployee is null)
            throw new ApiException($"Email '{request.Email}' is not found.") { Code = (int)HttpStatusCode.NotFound };

        var foundAccount = await _accountRepository.FindOneByPk(foundEmployee.Nik);
        if (foundAccount is null)
            throw new ApiException($"Failed to login.");

        var isMatch = _bcryptUtil.VerifyPassword(request.Password, foundAccount.Password);
        if (!isMatch)
            throw new ApiException($"Password does not match.") { Code = (int)HttpStatusCode.BadRequest };

        var foundAccountRoles =
            await _accountRoleRepository.FindManyByAccountNikIncludeRoleAsync(foundAccount.EmployeeNik);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, foundEmployee.Pk),
            new(ClaimTypes.Name, foundEmployee.Fullname),
            new(ClaimTypes.Email, foundEmployee.Email)
        };

        foundAccountRoles.ToList().ForEach(ar => { claims.Add(new Claim(ClaimTypes.Role, ar.Role.Name)); });

        var generatedAccessToken = _jwtUtil.GenerateAccessToken(claims);
        var generatedRefreshToken = _jwtUtil.GenerateRefreshToken();

        await _refreshTokenRepository.InsertOne(new UserToken
        {
            Pk = foundEmployee.Pk,
            RefreshToken = generatedRefreshToken,
            ExpiryDate = DateTime.Now.AddHours(_config.GetValue<double>("jwt:RefreshTokenExpiresInHour"))
        });

        return new LoginResponse
        {
            AccessToken = generatedAccessToken,
            RefreshToken = generatedRefreshToken
        };
    }
}