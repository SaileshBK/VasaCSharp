using VasaCSharp.Random.Interface;

namespace VasaCSharp.Random.Utilities;

public static class PasswordGeneratorUtility
{
    public static void Generate(IPasswordGenerator passwordGenerator)
    {
        // Grab the passwordLength from user Input.
        passwordGenerator.GetValidUserInput(out var passwordLength);           
                                                     
        // Generates password using Random Chars.
        Custom.WriteLine(passwordGenerator.GenerateRandomPassword(passwordLength));
        
        // Testing New Way Of Calling Private Methods in .Net 8
        var randomPasswordGenerator = new PasswordGenerator();
        Custom.WriteLine(Accessor.GetEndMessageMethod(randomPasswordGenerator));
    }
}