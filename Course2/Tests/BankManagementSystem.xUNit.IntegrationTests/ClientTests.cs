using System.Net.Http.Json;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.xUNit.IntegrationTests.Configurations;

namespace BankManagementSystem.xUNit.IntegrationTests;

public class ClientTests : BaseTestEntity
{
    [Fact]
    public async Task GetAll_ShouldReturnAllClients()
    {
        // Arrange
        var _client = CreateHttpClient();

        // Act
        var response = await _client.GetAsync("/api/Client");

        // Assert
        response.EnsureSuccessStatusCode();
        var clients = await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
        Assert.True(clients?.Any() == true);
    }
}