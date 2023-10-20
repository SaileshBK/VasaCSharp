using System.Runtime.InteropServices;
using VasaCSharp.Random.Interface;

namespace VasaCSharp.Random.Utilities;

public static class PasswordGeneratorUtility
{
    public static void Menu(IPasswordGenerator passwordGenerator)
    {
        var generatedPassword = new List<string>();
        while (true)
        {
            Custom.Menu();
            if (Enum.TryParse(Console.ReadLine(), out MenuOption userSelection))
            {
                switch (userSelection)
                {
                    case MenuOption.GeneratePassword:
                        Generate(passwordGenerator, generatedPassword);
                        break;
                    case MenuOption.ShowHistory:
                        PasswordHistory(generatedPassword);
                        break;
                    case MenuOption.Exit:
                        // Testing New Way Of Calling Private Methods in .Net 8
                        var randomPasswordGenerator = new PasswordGenerator();
                        Custom.WriteLine(Accessor.GetEndMessageMethod(randomPasswordGenerator));
                        return;
                    default:
                        return;
                }
            }
        }
    }
    
    private static void Generate(IPasswordGenerator passwordGenerator, List<string> generatedPassword)
    {
        // Grab the passwordLength from user Input.
        passwordGenerator.GetValidUserInput(out var passwordLength);           
                                                     
        // Generates password using Random Chars.
        var password = passwordGenerator.GenerateRandomPassword(passwordLength);
        generatedPassword.Add(password);
        Custom.WriteLine(password);
    }

    private static void PasswordHistory(List<string> generatedPassword)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Here are your generated passwords:");
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        
        // CollectionsMarshal.AsSpan() is more efficient for looping list than a traditional loop.
        // Note: Use case only when the list is immutable.  
        foreach (var password in CollectionsMarshal.AsSpan(generatedPassword))
        {
            Console.WriteLine(password);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("--------------------------------------");
        Console.ResetColor();
    }
}