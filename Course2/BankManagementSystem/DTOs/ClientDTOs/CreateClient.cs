using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs.ClientDTOs;

public record CreateClient
{
    [Required, MinLength(3), MaxLength(30)]
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public int Age { get; init; }
    
    [EmailAddress]
    public string Email { get; init; }
}