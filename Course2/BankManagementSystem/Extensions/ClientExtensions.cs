using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Models;

namespace BankManagementSystem.Extensions;

public static class ClientExtensions
{
    public static ClientDto ToClientDto(this Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Age = client.Age,
            Email = client.Email
        };
    }
}