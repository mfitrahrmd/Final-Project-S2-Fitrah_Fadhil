using API.Exceptions;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class AccountRepository<TContext> : CoreRepository<string, TbMAccount, TContext>, IAccountRepository
    where TContext : DbContext
{
    private IEmployeeRepository _employeeRepository;
    private IUniversityRepository _universityRepository;
    private IRoleRepository _roleRepository;

    public AccountRepository(TContext context, IEmployeeRepository employeeRepository,
        IUniversityRepository universityRepository, IRoleRepository roleRepository) : base(context)
    {
        (_employeeRepository, _universityRepository, _roleRepository) =
            (employeeRepository, universityRepository, roleRepository);
    }

    public async Task<TbMEmployee?> RegisterAsync(TbMEmployee employee)
    {
        TbMEmployee? registeredAccount;
        try
        {
            // check for duplicate nik
            var foundWithNik = await _employeeRepository.FindOneByPk(employee.Nik);
            if (foundWithNik is not null)
                throw new RepositoryException("Nik already exist");

            // check for duplicate email
            var foundWithEmail = await _employeeRepository.FindOneByEmailAsync(employee.Email);
            if (foundWithEmail is not null)
                throw new RepositoryException("email already exist");

            // check for duplicate phone number
            var foundWithPhoneNumber = await _employeeRepository.FindOneByPhoneNumberAsync(employee.PhoneNumber);
            if (foundWithEmail is not null)
                throw new RepositoryException("phone number already exist");

            // check if university already exist, if does use that existing university
            var foundUniversity =
                await _universityRepository.FindOneByNameAsync(employee.TbTrProfiling.Education.University.Name);
            if (foundUniversity is not null)
            {
                employee.TbTrProfiling.Education.University = null;
                employee.TbTrProfiling.Education.UniversityId = foundUniversity.Id;
            }

            // Default role 'User' for registration
            var userRole = await _roleRepository.FindOneOrInsertByName("User");
            employee.TbMAccount.TbTrAccountRoles.Add(new TbTrAccountRole
            {
                RoleId = userRole.Id
            });

            registeredAccount = await _employeeRepository.InsertOne(employee);
        }
        catch (Exception e)
        {
            throw;
        }

        return registeredAccount;
    }

    public async Task<TbMEmployee?> LoginAsync(TbMEmployee employee)
    {
        var foundEmployee = await _employeeRepository.FindOneByEmailAsync(employee.Email);

        if (foundEmployee is null)
            return null;

        var foundAccount = await FindOneByPk(foundEmployee.Nik);

        if (foundAccount is null)
            return null;

        if (!foundAccount.Password.Equals(employee.TbMAccount.Password))
            return null;

        return foundEmployee;
    }
}