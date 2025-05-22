using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CRUDOperationWithElasticSearch.Models.Helpers;

namespace CRUDOperationWithElasticSearch.Extensions;


public static class DistributedCacheExtensions
{
    /// <summary>
    /// Register a Redis to use as distributed cache when it is not development, otherwise it use a memory cache.
    /// </summary>
    public static void ConfigureDistributedAndMemoryCaches(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHybridCache();
        
        var redisOptions = GetRedisOptions(builder.Configuration);
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisOptions.ConnectionString;
        });
    }

    /// <summary>
    /// Get options of redis from the configuration. 
    /// </summary>
    /// <returns>Returns options of redis from the configuration if exists, otherwise create and return a new options.</returns>
    private static RedisOptions GetRedisOptions(IConfiguration configuration)
    {
        var redisOptions = configuration
            .GetSection(nameof(RedisOptions)).Get<RedisOptions>() ?? new RedisOptions();
        return redisOptions;
    }
}