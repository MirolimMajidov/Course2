using AutoMapper;
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
    private readonly IRepository<Client> _repository;
    private readonly IMapper _mapper;

    public ClientController(IRepository<Client> repository, [FromServices] IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<ClientDto> GetAll()
    {
        var clients = _repository.GetAll();
        var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
        return clientsDto;
        //return repository.GetAll().Select(c => c.ToDto());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var serversideClient = _repository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        var result = _mapper.Map<ClientDto>(serversideClient);
        return Ok(result);
        //return Ok(serversideClient.ToDto());
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
        _repository.Add(createdClient);

        return Created($"/api/client/{createdClient.Id}", createdClient.ToDto());
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = _repository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        _mapper.Map(updateClient, serversideClient);

        _repository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateClient updateClient)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = _repository.GetById(id);
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

        _repository.TryUpdate(id, serversideClient);

        return Ok(serversideClient.ToDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deletedClient = _repository.Delete(id);
        if (deletedClient is null)
            return NotFound();

        return Ok(deletedClient.ToDto());
    }
}