using System.Text;
using VasaCSharp.Random.Interface;

namespace VasaCSharp.Random;

public class RandomPasswordGenerator : IRandomPasswordGenerator
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+";

    public void GetValidUserInput(out int userInput)
    {
        while (true)
        {
            Console.WriteLine("Please, Enter the length of the Password: ");

            if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0)
            {
                return;
            }
        }
    }

    public void GenerateRandomPassword(int passwordLength)
    {
        var random = new System.Random();
        var password = new StringBuilder();

        for (var i = 0; i < passwordLength; i++)
        {
            var index = random.Next(Chars.Length);
            password.Append(Chars[index]);
        }

        Console.WriteLine(password.ToString());
    }
}