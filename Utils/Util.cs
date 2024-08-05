namespace Utils;

public static class Util
{
    public static string GetValidString(string prompt)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        while (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("Wrong Input, Try Again!");
            input = Console.ReadLine();
        }
        return input;
    }
    
    public static int NumParser(int startingNumber, int endingNumber)
    {
        int num;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out num) && num >= startingNumber && num <= endingNumber)
                break;
            Console.WriteLine("Invalid input, please try again.");
        }
        return num;
    }
    
    public static int NumParser(string prompt)
    {
        int num;
        Console.WriteLine(prompt);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out num))
                break;
            Console.WriteLine("Invalid input, please try again.");
        }
        return num;
    }
    
    public static bool AskToPlayAgain()
    {
        var response = GetValidString("Play another round? (yes or no)").ToLower();
        return response == "yes";
    }

    public static void DisplayResults(Dictionary<string, int> scores)
    {
        Console.Clear();
        Console.WriteLine("Results:");
        foreach (var player in scores)
        {
            Console.WriteLine($"Player Name: {player.Key}, Score: {player.Value}");
        }
    }

    public static string ReadPassword(string prompt)
    {
        Console.WriteLine(prompt);
        string password = string.Empty;
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}