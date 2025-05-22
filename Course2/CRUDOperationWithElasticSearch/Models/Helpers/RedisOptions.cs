namespace CRUDOperationWithElasticSearch.Models.Helpers;

public record RedisOptions
{
    /// <summary>
    /// The connection string used to connect to Redis.
    /// </summary>
    public string ConnectionString { get; init; } = "localhost";
}