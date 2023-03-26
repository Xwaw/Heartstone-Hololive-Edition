using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck _instance;

    private List<WildCard> _cards = new List<WildCard>();

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
            WildCard cardComponent = (WildCard)cardGameObject.AddComponent(typeof(WildCard));
            _cards.Add(cardComponent);
        }
        UpdatePositions();
    }

    public void RemoveCard(WildCard card)
    {
        _cards.Remove(card);
        UpdatePositions();
    }

    public void AddCard(WildCard card)
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
