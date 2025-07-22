using EventBus.RabbitMQ.Publishers.Managers;
using Microsoft.AspNetCore.Mvc;
using UserService.Messaging;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IEventPublisherManager eventPublisherManager) : ControllerBase
{
    private static readonly Dictionary<Guid, User> Items = new();

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(Items.Values);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetItems(Guid id)
    {
        if (!Items.TryGetValue(id, out User item))
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User item)
    {
        Items.Add(item.Id, item);

        var userCreated = new UserCreated { UserId = item.Id, UserName = item.Name };

        await eventPublisherManager.PublishAsync(userCreated);

        return Ok();
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!Items.TryGetValue(id, out User item))
            return NotFound();

        var userDeleted = new UserDeleted { UserId = item.Id, UserName = item.Name };
        await eventPublisherManager.PublishAsync(userDeleted);
        
        Items.Remove(id);
        return Ok(item);
    }
}