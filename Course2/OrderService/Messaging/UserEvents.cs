using EventBus.RabbitMQ.Subscribers.Models;

namespace OrderService.Messaging;

public record UserCreated : SubscribeEvent
{
    public required Guid UserId { get; init; }
    
    public required string UserName { get; init; }
}

public record UserDeleted : SubscribeEvent
{
    public required Guid UserId { get; init; }
    
    public required string UserName { get; init; }
}