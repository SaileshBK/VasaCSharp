using Microsoft.Extensions.DependencyInjection;
using VasaCSharp.Random;
using VasaCSharp.Random.Interface;

namespace VasaCSharp;

public static class Startup
{
    public static ServiceProvider ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IPasswordGenerator, PasswordGenerator>()
            .BuildServiceProvider();
        return serviceProvider;
    }
}