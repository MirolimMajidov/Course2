using BankManagementSystem.Application.DTOs.ClientDTOs;
using BankManagementSystem.Application.DTOs.WorkerDTOs;
using BankManagementSystem.Domain.Models;

namespace BankManagementSystem.Application.Extensions;

public static class PersonExtensions
{
    public static ClientDto ToDto(this Client client)
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
    
    public static WorkerDto ToDto(this Worker worker)
    {
        return new WorkerDto
        {
            Id = worker.Id,
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            Age = worker.Age
        };
    }
}