using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace Server;

public class ServerHub : Hub
{
    public static List<Lobby> lobbies = new List<Lobby>();

    public override Task OnConnectedAsync() 
    {
        Player player = new Player();

        Debug.WriteLine("yes");

        return base.OnConnectedAsync();
    }

    public List<Lobby> FetchLobbies()
    {
        Debug.WriteLine(lobbies.Count);
        return lobbies;
    }

    public async Task CreateLobby()
    {
        Debug.WriteLine("lobby");
        lobbies.Add(new Lobby());
    }

    public Task PlaceCard(string username)
    {
       return Task.CompletedTask;
    }
}