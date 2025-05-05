namespace BankManagementSystem.DTOs.ClientDTOs;

//public record CreateClient(string FirstName, string LastName, int Age, string Email);
public record CreateClient
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    public string Email { get; init; }
}