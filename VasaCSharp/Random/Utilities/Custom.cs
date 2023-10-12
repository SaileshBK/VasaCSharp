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
}