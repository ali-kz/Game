using static Utils.Util;
using Users;
namespace Games;

public class HackPassword(string name, string description, int pegiRating) : Game
{
    public sealed override string Name { get;  } = name;
    public sealed override string Description { get; } = description;
    public override int PEGIRating { get; } = pegiRating;
    protected override Dictionary<string, int> Scores { get; set; }  = new Dictionary<string, int>();
    private readonly string[] _words = ["ali", "pride", "taav", "akbar", "hassan"];
    private string? _chosenWord;

    protected override void Play(Player player)
    {
        while (true)
        {
            StartGame(player);
            if (!AskToPlayAgain())
            {
                DisplayResults(Scores);
                break;
            }
            Console.Clear();
        }
    }
    
    private void StartGame(Player player)
    {
        ChooseWord();
        Console.Clear();
        Player(player);
    }
    
    private void ChooseWord()
    {
        foreach (var name in _words)
        {
            Console.WriteLine($" {name}");
        }
        
        _chosenWord = GetValidString("What word do you want to choose? ");
    }
    
    private void Player(Player player)
    {
        Console.WriteLine("Guess the word:\n ");
        foreach (var name in _words)
        {
            Console.WriteLine($" {name}");
        }

        var counter = 0;
        var hasWon = false;

        do
        {
            var choice = GetValidString("Enter your guess: ");;
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
        Scores[player.Name] = counter;
    }
}