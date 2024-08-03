namespace GamesStructure;

public abstract class Game
{
    public abstract string Name { get; set; }
    protected abstract Dictionary<string, int> Scores { get; set; }
    
    protected readonly Random Random = new Random();
    public void Start(string playerName)
    {
        Console.WriteLine($"{Name} started");
        Play(playerName);
    }
    
    protected abstract void Play(string playerName);
    
    protected static bool AskToPlayAgain()
    {
        var response = GetValidString("Play another round? (yes or no)").ToLower();
        return response == "yes";
    }

    protected void DisplayResults()
    {
        Console.Clear();
        Console.WriteLine("Results:");
        foreach (var player in Scores)
        {
            Console.WriteLine($"Player Name: {player.Key}, Score: {player.Value}");
        }
    }
    
    protected static string GetValidString(string prompt)
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
    
    protected static int NumParser(int startingNumber, int endingNumber)
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
}