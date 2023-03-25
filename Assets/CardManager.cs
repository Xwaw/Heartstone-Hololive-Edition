using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Deck._istance.CreateCards(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
