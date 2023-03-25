using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update 
    // -4, -0.7
    public static Map _istance;

    public List<WildCard> listOfCards = new List<WildCard>();
    void Start()
    {
        _istance = this;
    }

    public void AddCardToMap(WildCard card) 
    {
        if (listOfCards.Contains(card)) {
            listOfCards.Remove(card);
            Deck._istance.AddCard(card);
            UpdateLocation();
            return;
        }
        if (listOfCards.Count == 4) {
            return;
        }
        listOfCards.Add(card);
        Deck._istance.RemoveCard(card);
        UpdateLocation();
    }

    private void UpdateLocation()
    {
        for (int i = 0; i < listOfCards.Count; i++) 
        {
            listOfCards[i].gameObject.transform.position = new Vector2(-4 + i + i, -0.7f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
