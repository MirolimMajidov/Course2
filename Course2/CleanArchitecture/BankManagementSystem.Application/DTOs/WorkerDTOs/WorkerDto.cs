namespace BankManagementSystem.Application.DTOs.WorkerDTOs;

public record WorkerDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
}