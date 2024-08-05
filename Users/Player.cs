namespace Users;

public class Player(string name, int age, string password)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
    public string Password { get; } = password;
}