using EventBus.RabbitMQ.Subscribers.Models;

namespace OrderService.Messaging;

public class UserCreatedHandler(ILogger<UserCreatedHandler> logger) : IEventSubscriber<UserCreated>
{
    public async Task HandleAsync(UserCreated @event)
    {
        logger.LogInformation("EventId ({EventId}): '{UserName}' user is created with the {UserId} id", @event.EventId,
            @event.UserName, @event.UserId);

        await Task.CompletedTask;
    }
}

// public class UserDeletedHandler : IEventSubscriber<UserDeleted>
// {
//     private readonly ILogger<UserDeletedHandler> _logger;
//
//     public UserDeletedHandler(ILogger<UserDeletedHandler> logger)
//     {
//         _logger = logger;
//     }
//
//     public async Task HandleAsync(UserDeleted @event)
//     {
//         _logger.LogInformation("EventId ({EventId}): '{UserName}' user is deleted with the {UserId} id", @event.EventId,
//             @event.UserName, @event.UserId);
//
//         await Task.CompletedTask;
//     }
// }