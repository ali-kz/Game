using static Utils.Util;
using Users;
namespace Games;

public abstract class Game
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int PEGIRating { get; }
    protected abstract Dictionary<string, int> Scores { get; set; }
    protected readonly Random Random = new Random();
    
    public void Start(Player player)
    {
        Console.WriteLine($"{Name} started");
        Play(player);
    }
    
    protected abstract void Play(Player player);
}