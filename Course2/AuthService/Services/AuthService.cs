using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services;

public class AuthService
{
    private static readonly User[] Users =
    [
        new User { Id = 1, Name = "Ali", Email = "ali@gmail.com", Password = "123", Role = "Admin" },
        new User { Id = 2, Name = "Vali", Email = "vali@gmail.com", Password = "1234", Role = "User" }
    ];

    public async Task<TokenInfo> Login(string username, string password)
    {
        var user = Users.SingleOrDefault(x => x.Email == username && x.Password == password);

        return await GeneratedJWT(user);
    }

    public async Task<TokenInfo> RefreshToken(string refreshToken)
    {
        var user = Users.SingleOrDefault(x => x.RefreshToken == refreshToken);

        return await GeneratedJWT(user);
    }

    async Task<TokenInfo> GeneratedJWT(User user)
    {
        if (user is null)
            throw new ArgumentException("Invalid username or password.");

        var userRoles = new string[] { user.Role ?? "User" };

        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        };

        foreach (var userRole in userRoles)
            claims.Add(new Claim(ClaimTypes.Role, userRole));

        var expireTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME));
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: expireTime,
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken;
        await Task.CompletedTask;

        return new TokenInfo { AccessToken = accessToken, RefreshToken = refreshToken, ExpireTime = expireTime };
    }
}