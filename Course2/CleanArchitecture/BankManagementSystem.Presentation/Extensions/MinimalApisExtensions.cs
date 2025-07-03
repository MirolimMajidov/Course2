using Microsoft.AspNetCore.Builder;

namespace BankManagementSystem.Presentation.Extensions;

public static class MinimalApisExtensions
{
    public static void MapAllMinimalAPIs(this WebApplication app)
    {
        app.MapServerAPIs();
        app.MapWorkerAPIs();
    }
}