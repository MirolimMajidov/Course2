namespace BankManagementSystem.Application.DTOs.ClientDTOs;

public record ClientDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    public string Email { get; init; }
}