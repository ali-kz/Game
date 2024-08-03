using GamesStructure;

namespace GameNet;

public class GameNet(params Game[] games)
{
    public void Login(string playerName)
    {
        Console.Clear();
        Console.WriteLine($"Welcome {playerName}!");
        ShowMenu(playerName);
    }

    private void ShowMenu(string playerName)
    {
        Console.WriteLine("Which game do you want to play?");
        for (int i = 1; i<= games.Length; i++)
        {
            Console.WriteLine($"{i}) {games[i-1].Name}");
        }
        PlayGame(playerName);
    }


    private void PlayGame(string playerName)
    {
        int playerChoice = NumParser(1, games.Length + 1);

        var game = games[playerChoice - 1];
        game.Start(playerName);
    }
    
    private static int NumParser(int startingNumber, int endingNumber)
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