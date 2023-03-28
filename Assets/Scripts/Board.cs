using System;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

#nullable enable

public class Board : MonoBehaviour
{
    public static Board _instance;
    private const int MAX_BOARD_CARDS = 4;

    [SerializeField]
    private List<Card> _cards = new List<Card>();

    void Awake()
    {
        if( _instance == null )
            _instance = this;
    }

    public Card? SpawnCard(Type card, Player? owner = null) 
    {
        GameObject cardObject = Instantiate(CardManager.GetCardPrefab(), CardManager.GetDeckParent().transform);
        Card? cardObjectComponent = (Card?)cardObject?.AddComponent(card);

        if(cardObjectComponent is null) {
            return null;
        }

        if(owner is null)
        {
            cardObjectComponent.owner = Player.MainPlayer;
        }
        else 
        {
            cardObjectComponent.owner = owner;
        }

        _cards.Add(cardObjectComponent);
        UpdatePositions();

        return cardObjectComponent;
    }

    public bool AddToBoard(Card card) 
    {
        if (!_cards.Contains(card)) 
        {
            if (_cards.Count == MAX_BOARD_CARDS) {
                return false;
            }
            card.IsOnBoard = true;
            _cards.Add(card);
            card.OnAttack();
            Deck._instance.RemoveCard(card);

            NetworkManager._hub.InvokeAsync("PlaceCard");

            return true;
        }

        UpdatePositions();

        return false;
    }

    public Vector2 GetLastPosition() 
    {
        if(_cards.Count == MAX_BOARD_CARDS) {
            return Vector2.zero;
        }

        if(_cards.Count == 0) {
            return new Vector2(44, -0.7f);
        }

        return new Vector2(44 + _cards.Count+1 * _cards.Count, -0.7f);
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < _cards.Count; i++) 
        {
            _cards[i].gameObject.transform.position = new Vector2(44 + i + i, -0.7f);   
        }
    }
}
