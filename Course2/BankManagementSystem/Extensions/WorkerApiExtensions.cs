namespace BankManagementSystem.Extensions;

public static class WorkerApiExtensions
{
    public static void MapWorkerAPIs(this WebApplication app)
    {
        app.MapGet("api/Worker", () =>
        {
            return Results.Ok(new { Info = "Bank Management System" });
        });

        app.MapPost("api/Worker", (string message) =>
        {
            return Results.Ok(new { Message =  $"Hi, {message}" });
        });
    }
}