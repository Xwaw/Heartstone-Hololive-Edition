using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map _instance;

    private List<WildCard> _cards = new List<WildCard>();

    void Awake()
    {
        if( _instance == null )
            _instance = this;
    }

    public void CardClicked(WildCard card) 
    {
        if (_cards.Contains(card)) 
        {
            _cards.Remove(card);
            Deck._instance.AddCard(card);
        }
        else
        {
            if (_cards.Count == 4) {
                return;
            }

            _cards.Add(card);
            Deck._instance.RemoveCard(card);
        }

        UpdatePositions();
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < _cards.Count; i++) 
        {
            _cards[i].gameObject.transform.position = new Vector2(-4 + i + i, -0.7f);
        }
    }
}
