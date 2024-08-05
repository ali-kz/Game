using Users;
using static Utils.Util;
namespace Games;

public class FindNumber(string name, string description, int pegiRating)  : Game
{
    public sealed override string Name { get; } = name;
    public sealed override string Description { get; } = description;
    public override int PEGIRating { get; } = pegiRating;
    protected override Dictionary<string, int> Scores { get; set; } = new Dictionary<string, int>();
    protected override void Play(Player player)
    {
        while (true)
        {
            var randomNumber = Random.Next(1, 101);
            var counter = 0;

            PlayGame(randomNumber, ref counter);

            Scores[player.Name] = counter;

            if (!AskToPlayAgain())
            {
                DisplayResults(Scores);
                break;
            }
            Console.Clear();
        }
    }

    private void PlayGame(int randomNumber, ref int counter)
    {
        int enteredNum = GetUserNumber();

        while (true)
        {
            counter++;
            if (enteredNum < randomNumber)
            {
                Console.WriteLine("BIGGER!");
                enteredNum = GetUserNumber();
            }
            else if (enteredNum > randomNumber)
            {
                Console.WriteLine("SMALLER!");
                enteredNum = GetUserNumber();
            }
            else
            {
                Console.WriteLine($"Congrats! You have won in {counter} steps!");
                break;
            }
        }
    }

    private int GetUserNumber()
    {
        Console.WriteLine("Please enter your number (between 1 and 100):");
        return NumParser(1, 100);
    }
}