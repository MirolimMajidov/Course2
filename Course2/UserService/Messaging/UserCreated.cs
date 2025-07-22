using EventBus.RabbitMQ.Publishers.Models;

namespace UserService.Messaging;

public record UserCreated : PublishEvent
{
    public required Guid UserId { get; init; }
    
    public required string UserName { get; init; }
}

public record UserDeleted : PublishEvent
{
    public required Guid UserId { get; init; }
    
    public required string UserName { get; init; }
}