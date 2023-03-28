using Microsoft.AspNetCore.SignalR.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenager : MonoBehaviour
{
    public Button createLobbyButton;
    public static LobbyMenager _instance;

    public List<Lobby> newLobby = new List<Lobby>();
    // Start is called before the first frame update
    void Start()
    {
        createLobbyButton = GetComponent<Button>();
        createLobbyButton.onClick.AddListener(CreateLobby);

        
    }

    private void Awake()
    {
        _instance = this;

    }

    private void CreateLobby()
    {
        NetworkManager._hub.InvokeAsync("CreateLobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
