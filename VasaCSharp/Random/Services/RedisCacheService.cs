using StackExchange.Redis;

namespace VasaCSharp.Random.Services;

public interface IRedisCacheService
{
    Task<string?> GetCacheValueAsync(string key);
    Task SetCacheValueAsync(string key, string value);
}

public class RedisCacheService : IRedisCacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    
    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<string?> GetCacheValueAsync(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return null;
        }
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringGetAsync(key);
    }
    
    public async Task SetCacheValueAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        await db.StringSetAsync(key, value);
    }
}