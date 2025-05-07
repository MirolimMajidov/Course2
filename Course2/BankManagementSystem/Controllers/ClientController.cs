using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Extensions;
using BankManagementSystem.Models;
using BankManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    [HttpGet]
    public IEnumerable<ClientDto> GetAll([FromServices] IClientRepository repository)
    {
        return repository.GetAll().Select(c => c.ToDto());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id, [FromServices] IClientRepository repository)
    {
        var serversideClient = repository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        return Ok(serversideClient.ToDto());
    }

    [HttpPost]
    public IActionResult Create(CreateClient createClient, [FromServices] IClientRepository repository)
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
        repository.Add(createdClient);

        return Created($"/api/client/{createdClient.Id}", createdClient.ToDto());
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateClient updateClient, [FromServices] IClientRepository repository)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = repository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        serversideClient.FirstName = updateClient.FirstName;
        serversideClient.LastName = updateClient.LastName;
        serversideClient.Age = updateClient.Age;

        repository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateClient updateClient,
        [FromServices] IClientRepository repository)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = repository.GetById(id);
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

        repository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id, [FromServices] IClientRepository _repository)
    {
        var deletedClient = _repository.Delete(id);
        if (deletedClient is null)
            return NotFound();

        return Ok(deletedClient.ToDto());
    }
}