using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private static readonly List<Client> Clients =
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

    [HttpGet]
    //[HttpGet("[action]")]
    //[HttpGet("GetAll")]
    public IEnumerable<Client> GetAll()
    {
        return Clients;
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var client = Clients.SingleOrDefault(x => x.Id == id);
        if(client is null)
            return NotFound();

        return Ok(client);
    }

    [HttpPost]
    public IActionResult Test()
    {
        return Ok("Test");
    }
}