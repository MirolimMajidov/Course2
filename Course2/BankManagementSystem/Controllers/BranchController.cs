using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Infrastructure.Repositories;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchRepository repository)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var clientsDto = repository.GetAll()
                //.IgnoreAutoIncludes()
                //.Include(b=>b.Workers)
                .ToArray()
            ;
        // foreach (var client in clientsDto)
        // {
        //     _ = client.Workers;
        // }

        return Ok(clientsDto);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var client = repository.GetById(id);
        if (client is null)
            return NotFound();

        return Ok(client);
    }
}