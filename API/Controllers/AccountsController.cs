using System.Net;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : CoreController<IAccountRepository, string, TbMAccount>
{
    private readonly AuthService _authService;

    public AccountsController(IAccountRepository accountRepository, AuthService authService, IMapper mapper) : base(accountRepository, mapper)
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