using UnityEngine;

public class CardManager : MonoBehaviour
{
    void Start()
    {
        Deck._instance.CreateCards(6);
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

                Debug.Log("awvrawrvawvrawt");
                cardGameObject.ShowInfo();
            }
        }
    }
}
