using Microsoft.AspNetCore.TestHost;

namespace BankManagementSystem.xUNit.IntegrationTests.Configurations;

public abstract class BaseTestEntity
{
    protected TestServer Server = new ServerApiFactory().Server;
}