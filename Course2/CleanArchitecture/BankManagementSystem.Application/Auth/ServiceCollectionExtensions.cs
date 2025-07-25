using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BankManagementSystem.Application.Auth;

/// <summary>
/// See here to get more information: https://metanit.com/sharp/aspnet6/13.2.php
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddMyAuth(this IServiceCollection service)
    {
        service.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", 
                policy =>
                {
                    policy.RequireRole("Admin");
                    policy.RequireRole("Editor");
                });
            options.AddPolicy("UserOnly", policy =>
            {
                policy.RequireRole("User");
                policy.RequireRole("ProUser");
            });
        });
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                };
            });
    }
}
