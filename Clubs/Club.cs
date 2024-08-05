using Games;
using Users;
using static Utils.Util;
using static System.Console;

namespace Clubs;
public class PlayerClub()
{
    private readonly List<Game> _games = new List<Game>();
    private readonly List<Player> _players = new List<Player>();
    private Player _currentPlayer;
    public PlayerClub(List<Game> games) : this()
    {
        _games.AddRange(games);
    }
    public void Open()
    {
        while (true)
        {
            WriteLine("Welcome to our Club!");
            WriteLine("1) Login");
            WriteLine("2) Signup");
            WriteLine("3) Exit");
            WriteLine("What do you Want:");
            switch (NumParser(1,3))
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Signup();
                    break;
                case 3:
                    return;
                default:
                    WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    private void Signup()
    {
        var playerName = GetValidString("Please Enter Your Name:");
        var playerAge = NumParser("Please Enter Your Age:");
        var playerPassword = ReadPassword("Please Enter Your password:");
        var newPlayer = new Player(playerName, playerAge, playerPassword);
        _players.Add(newPlayer);
        _currentPlayer = newPlayer;
        Clear();
        ShowGamesMenu();
    }

    private void Login()
    {
        var playerName = GetValidString("Please Enter Your Name:");
        var playerPassword = ReadPassword("Please Enter Your password:");
        _currentPlayer = _players.Find(p => p.Name == playerName && p.Password == playerPassword);
        
        if (_currentPlayer != null)
        {
            ShowGamesMenu();
        }
        else
        {
            WriteLine("Invalid credentials. Try again.");
        }
    }
    public void AddGame(Game game)
    {
        _games.Add(game);
    }
    private void ShowGamesMenu()
    {

        WriteLine("Which Game Do You Want To Play?");
        for (int i = 0; i < _games.Count; i++)
        {
            if (_games[i].PEGIRating <= _currentPlayer.Age)
            {
                WriteLine($"{i + 1}. {_games[i].Name} (PEGI {_games[i].PEGIRating})");
            }
        }
        WriteLine($"{_games.Count + 1}) Exit");
        PlayGame();
    }
    private void PlayGame()
    {
        var playerChoice = NumParser(1, _games.Count + 1);
        
        if (playerChoice == _games.Count + 1)
        {
            _currentPlayer = null;
            return;
        }
        
        var game = _games[playerChoice - 1];
        WriteLine("Do you want to see games description?\n (yes or no)");
        var seeDesc = ReadLine();
        if (seeDesc == "yes")
        {
            WriteLine(game.Description);
            game.Start(_currentPlayer);
        }
        else if (seeDesc == "no")
        {
            game.Start(_currentPlayer);
        }
        else WriteLine("Invalid Entry!");

        ShowGamesMenu();
    }
}