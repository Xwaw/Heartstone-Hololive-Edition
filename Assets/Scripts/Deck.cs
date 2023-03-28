using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck _instance;

    private List<Card> _cards = new List<Card>();

    [SerializeField]
    private GameObject CardObject;

    void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

    public void CreateCards(int count) 
    {
        Type[] types = CardManager.GetDrawableCards();
        System.Random rng = new System.Random();

        for (int i = 0; i < count; i++)
        {
            GameObject cardGameObject = Instantiate(CardObject, Vector2.one, Quaternion.identity, CardManager.GetDeckParent().transform);

            Card card = (Card)cardGameObject.AddComponent(types[rng.Next(0, types.Length)]);
            card.owner = Player.MainPlayer;
            _cards.Add(card);
        }

        UpdatePositions();
    }

    public void RemoveCard(Card card)
    {
        _cards.Remove(card);
        UpdatePositions();
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
        UpdatePositions();
    }

    public void UpdatePositions()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].gameObject.transform.position = new Vector2(44 + i + i, -3.8f);
        }
    }
}
