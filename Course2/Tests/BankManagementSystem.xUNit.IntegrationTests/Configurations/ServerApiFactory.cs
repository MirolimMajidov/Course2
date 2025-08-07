using BankManagementSystem.API;
using BankManagementSystem.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagementSystem.xUNit.IntegrationTests.Configurations;


public class ServerApiFactory : WebApplicationFactory<EntryPoint>
{
    // protected override void ConfigureWebHost(IWebHostBuilder builder)
    // {
    //     builder.UseEnvironment("Test");
    //
    //     builder.ConfigureServices(services =>
    //     {
    //         // Remove the existing context configuration
    //         var descriptor = services.SingleOrDefault(
    //             d => d.ServiceType == typeof(DbContextOptions<BankContext>));
    //         if (descriptor != null)
    //         {
    //             services.Remove(descriptor);
    //         }
    //
    //         // Add an in-memory database for testing
    //         services.AddDbContext<BankContext>(options => { options.UseInMemoryDatabase("InMemoryBankTest"); });
    //     });
    // }
}