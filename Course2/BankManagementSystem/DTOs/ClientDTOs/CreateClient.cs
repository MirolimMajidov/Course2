using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.DTOs.ClientDTOs;

//public record CreateClient(string FirstName, string LastName, int Age, string Email);
public record CreateClient
{
    //[FromRoute]
    [Required, MinLength(3), MaxLength(30)]
    public string FirstName { get; init; }
    
    //[FromHeader]
    public string LastName { get; init; }
    
    //[FromForm]
    public int Age { get; init; }
    
    [EmailAddress]
    public string Email { get; init; }
}