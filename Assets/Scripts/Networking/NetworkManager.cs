using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
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
            _hub.InvokeAsync<List<Lobby>>("FetchLobbies").ContinueWith((lobbies) =>
            {
                foreach (Lobby b in lobbies.Result)
                {
                    Debug.Log(b);
                }
                Debug.Log(lobbies.Result.Count);
            });
        });
    }

    private void Awake()
    {
        CreateConnection();
    }
}