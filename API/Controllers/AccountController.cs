using API.DTOs;
using API.Exceptions;
using API.Models;
using API.Repositories.Contracts;
using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly IAccountRepository _accountRepository;
    private readonly Jwt _jwtUtil;

    public AccountController(IAccountRepository accountRepository, Jwt jwtUtil)
    {
        _accountRepository = accountRepository;
        _jwtUtil = jwtUtil;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterInput data)
    {
        TbMEmployee? registered = null;
        try
        {
            registered = await _accountRepository.RegisterAsync(data.ToEmployeeEntity());

            if (registered is null)
                return BadRequest();
        }
        catch (RepositoryException e)
        {
            return BadRequest();
        }
        return Created("", new RegisterOutput
        {
            Email = registered.Email
        });
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginInput data)
    {
        var loggedIn = await _accountRepository.LoginAsync(data.ToEmployeeEntity());

        if (loggedIn is null)
            return BadRequest();

        var accessToken = _jwtUtil.GenerateToken(new Payload($"{loggedIn.FirstName} {loggedIn.LastName}", loggedIn.Email, "User"));

        return Ok(new LoginOutput
        {
            AccessToken = accessToken
        });
    }
}