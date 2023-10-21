using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using VasaCSharp.Random;
using VasaCSharp.Random.Interface;
using VasaCSharp.Random.Services;

namespace VasaCSharp;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IPasswordGenerator, PasswordGenerator>()
            .AddSingleton<IConnectionMultiplexer>(x => 
                ConnectionMultiplexer.Connect("localhost:6379"))
            .AddSingleton<IRedisCacheService, RedisCacheService>()
            .BuildServiceProvider();
        return serviceProvider;
    }
}