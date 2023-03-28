public class Player
{
    public static Player MainPlayer = new Player("Puzonne");

    public string Name { get; set; }

    public bool OwnedByLocal() => this == MainPlayer;

    public Player(string name) 
    {
        Name = name;
    }
}
