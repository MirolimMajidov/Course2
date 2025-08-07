using System.Net;
using System.Net.Http.Json;
using BankManagementSystem.Application.DTOs.ClientDTOs;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.xUNit.IntegrationTests.Configurations;

namespace BankManagementSystem.xUNit.IntegrationTests;

public class ClientTests : BaseTestEntity
{
    [Fact]
    public async Task GetAll_ShouldReturnAllClients()
    {
        // Arrange
        var client = CreateHttpClient();

        // Act
        var response = await client.GetAsync("/api/Client");

        // Assert
        response.EnsureSuccessStatusCode();
        var clients = await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
        Assert.True(clients?.Any() == true);
    }

    [Fact]
    public async Task GetById_ShouldNotReturnClientByInvalidId()
    {
        var id = Guid.NewGuid();
        var client = CreateHttpClient();

        var response = await client.GetAsync($"/api/Client/{id}");
       
        Assert.False(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetById_ShouldReturnClientById()
    {
        var id = await GetFirstClientId();
        var client = CreateHttpClient();

        var response = await client.GetAsync($"/api/Client/{id}");

        response.EnsureSuccessStatusCode();
        var clientData = await response.Content.ReadFromJsonAsync<Client>();
        Assert.NotNull(clientData);
        Assert.Equal(id, clientData.Id);
    }

    [Fact]
    public async Task Create_ShouldNotCreateNewClientWithInvalidData()
    {
        var client = CreateHttpClient();
        var newClient = new Client(); // Missing required fields
        
        var response = await client.PostAsJsonAsync("/api/Client", newClient);

        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Create_ShouldCreateNewClient()
    {
        var client = CreateHttpClient();
        var newClient = new CreateClient
        {
            FirstName = "Testas",
            LastName = "Client",
            Age = 30,
            Email =  $"{Guid.NewGuid()}@example.com"
        };

        var response = await client.PostAsJsonAsync("/api/Client", newClient);

        response.EnsureSuccessStatusCode();
        var createdClient = await response.Content.ReadFromJsonAsync<Client>();
        Assert.NotNull(createdClient);
        Assert.Equal(newClient.FirstName, createdClient.FirstName);
    }

    [Fact]
    public async Task Update_ShouldNotUpdateByInvalidId()
    {
        var client = CreateHttpClient();
        var clientId = Guid.NewGuid();
        var updateClient = new UpdateClient
        {
            FirstName = "Updated",
            LastName = "Client",
            Age = 35
        };

        var response = await client.PutAsJsonAsync($"/api/Client?id={clientId}", updateClient);

        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Update_ShouldUpdateByValidId()
    {
        var client = CreateHttpClient();
        var clientId = await GetFirstClientId();
        var updateClient = new UpdateClient
        {
            FirstName = "Updated",
            LastName = "Client",
            Age = 35
        };

        var response = await client.PutAsJsonAsync($"/api/Client?id={clientId}", updateClient);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Delete_ShouldNotDeleteClientByInvalidId()
    {
        var client = CreateHttpClient();
        var clientId = Guid.NewGuid();

        var response = await client.DeleteAsync($"/api/Client?id={clientId}");

        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Delete_ShouldDeleteClientByValidId()
    {
        var client = CreateHttpClient();
        var clientId = await GetFirstClientId();

        var response = await client.DeleteAsync($"/api/Client?id={clientId}");

        response.EnsureSuccessStatusCode();
    }

    #region Helper methdos

    private async Task<Guid> GetFirstClientId()
    {
        var client = CreateHttpClient();
        var response = await client.GetAsync("/api/Client");
        response.EnsureSuccessStatusCode();
        var clients = await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
        return clients!.First().Id;
    }

    #endregion
}