using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private static readonly Client[] Clients =
    [
        new Client
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Email = "John@test.tj"
        },
        new Client
        {
            Id = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Vali",
            Age = 10,
            Email = "Ali@test.tj"
        }
    ];

    [HttpGet(Name = "GetAll")]
    public IEnumerable<Client> GetAll()
    {
        return Clients;
    }

    [HttpPost(Name = "Test")]
    public IActionResult Test()
    {
        
        
        
        return Ok("Test");
    }
}