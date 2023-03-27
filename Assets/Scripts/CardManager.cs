using UnityEngine;

public class CardManager : MonoBehaviour
{
    void Start()
    {
        Deck._instance.CreateCards(6);
    }
}
