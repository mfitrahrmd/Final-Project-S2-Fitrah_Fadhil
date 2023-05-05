using System.Net;
using API.DTOs;
using API.DTOs.request;
using API.Models;
using API.Repositories.Contracts;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "admin")]
[Route("api/[controller]")]
[ApiController]
public class AccountsController : CoreController<IAccountRepository, string, Account, AccountDTO, InsertAccountRequest, UpdateAccountRequest>
{
    private readonly AuthService _authService;

    public AccountsController(IAccountRepository accountRepository, AuthService authService, IMapper mapper) : base(accountRepository, mapper)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [AllowAnonymous]
    [HttpPost("Auth")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);

        return StatusCode((int)HttpStatusCode.OK, result);
    }
}