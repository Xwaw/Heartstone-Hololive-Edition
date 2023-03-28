using System;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;

    [SerializeField]
    private GameObject _canvasPrefab;

    [SerializeField]
    private GameObject _cardPrefab;

    [SerializeField]
    private GameObject _deckParent;

    [SerializeField]
    private GameObject _attackCursor;

    public static GameObject GetDeckParent() => _instance._deckParent;

    public static GameObject GetCanvasPrefab() => _instance._canvasPrefab;

    public static GameObject GetCardPrefab() => _instance._cardPrefab;

    public static GameObject GetAttackCursor() => _instance._attackCursor;

    private static Type[] drawAbleCards = new Type[]
    {
        typeof(Ina),
    };

    public static Type[] GetDrawableCards() => drawAbleCards;

    void Start()
    {
        _instance = this;

        Deck._instance.CreateCards(6);

        //Board._instance.SpawnCard(typeof(Ina), new Player("not"));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 rayLine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayLine, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "Card") 
            {
                Card cardGameObject = hit.collider.gameObject.GetComponent<Card>();
                cardGameObject.ShowInfo();
            }
        }
    }
}
