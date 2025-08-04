using BankManagementSystem.API;
using BankManagementSystem.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagementSystem.xUNit.IntegrationTests.Configurations;


public class ServerApiFactory : WebApplicationFactory<EntryPoint>
{
}