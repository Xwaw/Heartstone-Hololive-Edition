using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager _instance;

    public static HubConnection _hub;

    private static void CreateConnection()
    {
        _hub = new HubConnectionBuilder()
            .WithUrl("https://localhost:52555/server")
            .Build();

        _hub.StartAsync().ContinueWith((_) =>
        {
            
        });
    }

    private void Awake()
    {
        CreateConnection();
    }
}