namespace BankManagementSystem.Application.DTOs.ClientDTOs;

public record PatchUpdateClient
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int? Age { get; init; }
}