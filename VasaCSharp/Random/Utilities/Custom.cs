namespace VasaCSharp.Random.Utilities;

public static class Custom
{
    public static void WriteLine(string message)
    {
        var colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        var random = new System.Random();
        var randomColor = colors[random.Next(colors.Length)];
        Console.ForegroundColor = randomColor;
        Console.WriteLine(message);
        // Reset the color to the default
        Console.ResetColor(); 
    }

    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Welcome To Password Generator Menu: ");
        Console.WriteLine("1. Generate Password");
        Console.WriteLine("2. View Password History");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter Your Choice: ");
    }
}