namespace BankManagementSystem.Extensions;

public static class MinimalApisExtensions
{
    public static void MapAllMinimalAPIs(this WebApplication app)
    {
        app.MapServerAPIs();
        app.MapWorkerAPIs();
    }
}