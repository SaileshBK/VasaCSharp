using Microsoft.Extensions.DependencyInjection;
using VasaCSharp.Random;
using VasaCSharp.Random.Interface;
using VasaCSharp.Random.Utilities;

namespace VasaCSharp
{
    internal static class Program
    {
        public static void Main()
        {
            var serviceProvider = Startup.ConfigureServices();
            var passwordGenerator = serviceProvider.GetRequiredService<IRandomPasswordGenerator>();
            
            // Grab the passwordLength from user Input.
            passwordGenerator.GetValidUserInput(out var passwordLength);           
                                                     
            // Generates password using Random Chars.
            passwordGenerator.GenerateRandomPassword(passwordLength);
            
            // Testing New Way Of Calling Private Methods in .Net 8
            var randomPasswordGenerator = new RandomPasswordGenerator();
            Console.WriteLine(Accessor.GetEndMessageMethod(randomPasswordGenerator));
        }
    }
}

