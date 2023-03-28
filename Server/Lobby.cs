public class Lobby 
{
    private readonly List<Player> Players = new List<Player>();

    public void Join(Player player)
    {
        if (Players.Count == 2) return;
        Players.Add(player);
    }
}
