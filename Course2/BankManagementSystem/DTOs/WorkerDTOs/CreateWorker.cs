using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.DTOs.WorkerDTOs;

public record CreateWorker
{
    [Required, MinLength(3), MaxLength(30)]
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public int Age { get; init; }
}