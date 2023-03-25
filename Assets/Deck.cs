using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update
    public static Deck _istance;
    public GameObject CardObject; // <= To jest ta karta która jest prefabem na dolnym pasku dziêki

    public List<WildCard> _cards = new List<WildCard>();
    void Start()
    {
        _istance = this;

        
    }

    public void CreateCards(int count) 
    {
        for (int i = 0; i < count; i++)
        {
            var nextCard = Instantiate(CardObject, Vector2.one, Quaternion.identity);
            nextCard.name = CardObject.name + i;
            nextCard.AddComponent(typeof(WildCard));
            _cards.Add(nextCard.GetComponent<WildCard>());
        }
        UpdateLocation();
    }

    public void RemoveCard(WildCard delCard)
    {
        _cards.Remove(delCard);
        UpdateLocation();
    }

    public void AddCard(WildCard newCard)
    {
        _cards.Add(newCard);
        UpdateLocation();
    }
    public void UpdateLocation()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].gameObject.transform.position = new Vector2(-6 + i + i, -3.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
