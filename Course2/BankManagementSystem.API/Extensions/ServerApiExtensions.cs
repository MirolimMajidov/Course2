namespace BankManagementSystem.API.Extensions;

public static class ServerApiExtensions
{
    public static void MapServerAPIs(this WebApplication app)
    {
        app.MapGet("api/ServerInfo", () =>
        {
            return Results.Ok(new { Info = "Bank Management System" });
        });

        app.MapPost("api/Message", (string message) =>
        {
            return Results.Ok(new { Message =  $"Hi, {message}" });
        });
    }
}