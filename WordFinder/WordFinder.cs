using GamesStructure;
namespace WordFinder;

public class WordFinder : Game
{
    public override string Name { get; set; } = "Word Game";
    protected override Dictionary<string, int> Scores { get; set; }  = new Dictionary<string, int>();
    private readonly string[] _words = { "ali", "prida", "taav", "akbar", "hassan" };
    private string? _chosenWord;

    protected override void Play(string playerName)
    {
        while (true)
        {
            StartGame(playerName);
            if (!AskToPlayAgain())
            {
                DisplayResults();
                break;
            }
            Console.Clear();
        }
    }
    
    private void StartGame(string playerName)
    {
        ChooseWord();
        Console.Clear();
        Player(playerName);
    }
    
    private void ChooseWord()
    {
        foreach (var name in _words)
        {
            Console.WriteLine($" {name}");
        }
        
        _chosenWord = GetValidString("What word do you want to choose? ");
    }
    
    private void Player(string playerName)
    {
        Console.WriteLine("Guess the word:\n ");
        foreach (var name in _words)
        {
            Console.WriteLine($" {name}");
        }

        int counter = 0;
        string choice;
        bool hasWon = false;

        do
        {
            choice = GetValidString("Enter your guess: ");;
            counter++;

            if (choice == _chosenWord)
            {
                Console.WriteLine($"Congrats! You have won in {counter} steps!");
                hasWon = true;
            }
            else
            {
                Console.WriteLine("Wrong answer! Try again!");
            }
        } while (!hasWon);
        Scores[playerName] = counter;
    }
}