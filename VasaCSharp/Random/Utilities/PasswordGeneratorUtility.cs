using System.Runtime.InteropServices;
using System.Xml;
using VasaCSharp.Random.Interface;

namespace VasaCSharp.Random.Utilities;

public static class PasswordGeneratorUtility
{
    private static readonly List<string> _generatedPasswords = new List<string>(); 
    public static void Menu(IPasswordGenerator passwordGenerator)
    {
        while (true)
        {
            Custom.Menu();
            if (Enum.TryParse(Console.ReadLine(), out MenuOption userSelection))
            {
                switch (userSelection)
                {
                    case MenuOption.GeneratePassword:
                        Generate(passwordGenerator);
                        break;
                    case MenuOption.ShowHistory:
                        PasswordHistory();
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
    
    private static void Generate(IPasswordGenerator passwordGenerator)
    {
        // Grab the passwordLength from user Input.
        passwordGenerator.GetValidUserInput(out var passwordLength);           
                                                     
        // Generates password using Random Chars.
        var password = passwordGenerator.GenerateRandomPassword(passwordLength);
        _generatedPasswords.Add(password);
        Custom.WriteLine(password);
    }

    private static void PasswordHistory()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Here are your generated passwords:");
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        // _generatedPasswords.ForEach(Console.WriteLine);
        
        // CollectionsMarshal.AsSpan() is more efficient for looping list than a traditional loop.
        // Note: Use case only when the list is immutable.  
        foreach (var password in CollectionsMarshal.AsSpan(_generatedPasswords))
        {
            Console.WriteLine(password);
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--------------------------------------");
        Console.ResetColor();
    }
}