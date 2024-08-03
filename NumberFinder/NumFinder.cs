using GamesStructure;
namespace NumberFinder;

public class NumFinder : Game
{
    public override string Name { get; set; } = "Number Finder";
    protected override Dictionary<string, int> Scores { get; set; } = new Dictionary<string, int>();
    protected override void Play(string playerName)
    {
        while (true)
        {
            int randomNumber = Random.Next(1, 101);
            int counter = 0;

            PlayGame(randomNumber, ref counter);

            Scores[playerName] = counter;

            if (!AskToPlayAgain())
            {
                DisplayResults();
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
