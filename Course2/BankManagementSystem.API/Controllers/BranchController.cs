using BankManagementSystem.API.Infrastructure.Database;
using BankManagementSystem.API.Infrastructure.Repositories;
using BankManagementSystem.API.DTOs.ClientDTOs;
using BankManagementSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchRepository repository, BankContext context, ILogger<BranchController> logger)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        //throw new Exception("Test");
        
        var clientsDto = repository.GetAll()
                //.IgnoreAutoIncludes()
                //.Include(b=>b.Workers)
                .ToArray()
            ;
        // foreach (var client in clientsDto)
        // {
        //     _ = client.Workers;
        // }

        logger.LogInformation("Fetched {Count} clients", clientsDto.Length);
        
        return Ok(clientsDto);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var client = repository.GetById(id);
        if (client is null)
            return NotFound();

        if (client.Address.Contains("Khujand"))
            context.Entry(client).Collection(p => p.Workers).Load();

        return Ok(client);
    }
}