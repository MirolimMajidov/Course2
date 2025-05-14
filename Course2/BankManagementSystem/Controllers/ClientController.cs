using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService service)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var clientsDto = service.GetAll();
        return Ok(clientsDto);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var client = service.GetById(id);
        if (client is null)
            return NotFound();

        return Ok(client);
    }

    [HttpPost]
    public IActionResult Create(CreateClient createClient)
    {
        var (validationResult, createdClient) = service.Add(createClient);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Created($"/api/client/{createdClient.Id}", createdClient);
    }

    [HttpPut]
    public IActionResult Update(Guid id, UpdateClient updateClient)
    {
        var result = service.TryUpdate(id, updateClient);
        if (!result)
            return NotFound();

        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateClient updateClient)
    {
        var result = service.TryUpdateSpecificProperties(id, updateClient);
        if (!result)
            return NotFound();

        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var result = service.TryDelete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}