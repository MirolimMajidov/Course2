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
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public IEnumerable<ClientDto> GetAll()
    {
        return _clientRepository.GetAll().Select(c => c.ToClientDto());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var serversideClient = _clientRepository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        return Ok(serversideClient.ToClientDto());
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
        _clientRepository.Add(createdClient);

        return Created($"/api/client/{createdClient.Id}", createdClient.ToClientDto());
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = _clientRepository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        serversideClient.FirstName = updateClient.FirstName;
        serversideClient.LastName = updateClient.LastName;
        serversideClient.Age = updateClient.Age;
        
        _clientRepository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToClientDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");
        
        var serversideClient = _clientRepository.GetById(id);
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
        
        _clientRepository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToClientDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deletedClient = _clientRepository.Delete(id);
        if (deletedClient is null)
            return NotFound();

        return Ok(deletedClient.ToClientDto());
    }
}