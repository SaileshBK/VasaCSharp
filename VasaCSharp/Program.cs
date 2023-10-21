using Microsoft.Extensions.DependencyInjection;
using VasaCSharp.Random.Interface;
using VasaCSharp.Random.Services;
using VasaCSharp.Random.Utilities;

namespace VasaCSharp
{
    internal static class Program
    {
        public static void Main()
        {
            var serviceProvider = Startup.ConfigureServices();
            var passwordGenerator = serviceProvider.GetRequiredService<IPasswordGenerator>();
            var redis = serviceProvider.GetRequiredService<IRedisCacheService>();
            PasswordGeneratorUtility.Menu(passwordGenerator, redis);
        }
    }
}

