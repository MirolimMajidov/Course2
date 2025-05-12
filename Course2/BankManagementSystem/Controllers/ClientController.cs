using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Extensions;
using BankManagementSystem.Models;
using BankManagementSystem.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public ClientController(IClientRepository repository, [FromServices] IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ClientDto> GetAll()
    {
        var clients = _repository.GetAll();
        if (!clients.Any())
            throw new Exception("No clients found");
        
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
    public IActionResult Create(CreateClient createClient, [FromServices] IValidator<CreateClient> validator)
    {
        // try
        // {
        if (string.IsNullOrEmpty(createClient.FirstName))
            throw new BadRequestException("First name is required!");
        // }
        // catch (Exception e)
        // {
        //     return BadRequest(e.Message);
        // }
        
        var result = validator.Validate(createClient);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

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
    public IActionResult Update(Guid id, UpdateClient updateClient, [FromServices] MapsterMapper.IMapper mapper)
    {
        if (updateClient is null)
            return BadRequest("Client is null");

        var serversideClient = _repository.GetById(id);
        if (serversideClient is null)
            return NotFound();

        mapper.Map(updateClient, serversideClient);

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