using BankManagementSystem.Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankManagementSystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchRepository repository, ILogger<BranchController> logger)
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
    //[Authorize]
    public IActionResult GetById(Guid id)
    {
        var client = repository.GetById(id);

        return Ok(client);
    }
}