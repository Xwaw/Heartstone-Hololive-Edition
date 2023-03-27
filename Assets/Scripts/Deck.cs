using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck _instance;

    private List<Card> _cards = new List<Card>();

    [SerializeField]
    private GameObject DeckParent;

    [SerializeField]
    private GameObject CardObject;

    void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

    public void CreateCards(int count) 
    {
        for (int i = 0; i < count; i++)
        {
            GameObject cardGameObject = Instantiate(CardObject, Vector2.one, Quaternion.identity, DeckParent.transform);
            _cards.Add(cardGameObject.GetComponent<Card>());
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
            _cards[i].gameObject.transform.position = new Vector2(-6 + i + i, -3.5f);
        }
    }
}
