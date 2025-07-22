using AuthService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController (Services.AuthService authService) : ControllerBase
{
    [HttpPost(Name = "LogIn")]
    public async Task<TokenInfo> LogIn(string username, string password)
    {
        var token = await authService.Login(username, password);
        return token;
    }
}