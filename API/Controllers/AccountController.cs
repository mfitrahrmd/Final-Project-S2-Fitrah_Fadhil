using System.Net;
using API.DTOs.request;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);

        return StatusCode((int)HttpStatusCode.OK, result);
    }
}