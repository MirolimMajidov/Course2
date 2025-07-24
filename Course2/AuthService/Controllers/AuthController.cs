using AuthService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController (Services.AuthService authService) : ControllerBase
{
    [HttpPost("LogIn")]
    public async Task<TokenInfo> LogIn(string username, string password)
    {
        var token = await authService.Login(username, password);
        return token;
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var token = await authService.RefreshToken(refreshToken);
        return Ok(token);
    }
}