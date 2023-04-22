using System.Net;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : CoreController<IAccountRepository, string, TbMAccount>
{
    private readonly AuthService _authService;

    public AccountController(IAccountRepository accountRepository, AuthService authService) : base(accountRepository)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [HttpPost("Auth")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);

        return StatusCode((int)HttpStatusCode.OK, result);
    }
}