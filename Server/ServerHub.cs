using Microsoft.AspNetCore.SignalR;

namespace Server;

public class ServerHub : Hub
{
    public override Task OnConnectedAsync() 
    {
        return base.OnConnectedAsync();
    }

    public Task PlaceCard()
    {
       return Task.CompletedTask;
    }
}