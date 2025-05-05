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
    public IActionResult Create(Client client)
    {
        if (client is null)
            return BadRequest("Client is null");

        client.Id = Guid.NewGuid();
        Clients.Add(client);
        
        return Created($"/api/client/{client.Id}", client);
    }

    [HttpPut]
    public IActionResult Update(Client client)
    {
        if (client is null)
            return BadRequest("Client is null");

        var oldClient = Clients.SingleOrDefault(x => x.Id == client.Id);
        if (oldClient is null)
            return NotFound();

        oldClient.FirstName = client.FirstName;
        oldClient.LastName = client.LastName;
        oldClient.Age = client.Age;
        oldClient.Email = client.Email;
        
        return Ok(oldClient);
    }
}