using System.Text;
using VasaCSharp.Random.Interface;
using VasaCSharp.Random.Utilities;

namespace VasaCSharp.Random;

public class PasswordGenerator : IPasswordGenerator
{
    public void GetValidUserInput(out int userInput)
    {
        while (true)
        {
            Custom.WriteLine("Please, Enter the length of the Password: ");

            if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0)
            {
                return;
            }
        }
    }

    public string GenerateRandomPassword(int passwordLength)
    {
        var random = new System.Random();
        var password = new StringBuilder();
        const string chars = Constants.Chars;

        for (var i = 0; i < passwordLength; i++)
        {
            var index = random.Next(chars.Length);
            password.Append(chars[index]);
        }

        return password.ToString();
    }

    private string EndMessage()
    {
        return "Thank You !";
    }
}