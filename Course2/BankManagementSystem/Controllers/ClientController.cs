using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Extensions;
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
    public IEnumerable<ClientDto> GetAll()
    {
        return Clients.Select(c => c.ToClientDto());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var client = Clients.SingleOrDefault(x => x.Id == id);
        if (client is null)
            return NotFound();

        return Ok(client.ToClientDto());
    }

    [HttpPost]
    public IActionResult Create(CreateClient createClient)
    {
        if (createClient is null)
            return BadRequest("Client is null");

        var createdClient = new Client
        {
            FirstName = createClient.FirstName,
            LastName = createClient.LastName,
            Age = createClient.Age,
            Email = createClient.Email
        };
        Clients.Add(createdClient);

        return Created($"/api/client/{createdClient.Id}", createdClient.ToClientDto());
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = Clients.SingleOrDefault(x => x.Id == id);
        if (serversideClient is null)
            return NotFound();

        serversideClient.FirstName = updateClient.FirstName;
        serversideClient.LastName = updateClient.LastName;
        serversideClient.Age = updateClient.Age;

        return Ok(serversideClient.ToClientDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = Clients.SingleOrDefault(x => x.Id == id);
        if (serversideClient is null)
            return NotFound();

        // if (updateClient.FirstName is not null)
        //     serversideClient.FirstName = updateClient.FirstName;

        var serversideClientType = serversideClient.GetType();
        var properties = updateClient.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(updateClient);
            if (value is not null)
            {
                var oldProperty = serversideClientType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serversideClient, value);
            }
        }

        return Ok(serversideClient.ToClientDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var serversideClient = Clients.SingleOrDefault(x => x.Id == id);
        if (serversideClient is null)
            return NotFound();

        Clients.Remove(serversideClient);

        return Ok(serversideClient.ToClientDto());
    }
}