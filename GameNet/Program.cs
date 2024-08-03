using GamesStructure;

Game numFinder = new NumberFinder.NumFinder();
Game wordFinder = new WordFinder.WordFinder();

var gameNet = new GameNet.GameNet(numFinder, wordFinder);

Console.WriteLine("Who is Playing?");
string playerName = Console.ReadLine();

gameNet.Login(playerName);
