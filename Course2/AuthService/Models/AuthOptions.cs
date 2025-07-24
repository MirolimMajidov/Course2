using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Models;

internal class AuthOptions
{
    public const string ISSUER = "BankServer";
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "2EC1EE51-1100-4348-BF22-EEB6CB8B0695";
    public const int LIFETIME = 30;
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}