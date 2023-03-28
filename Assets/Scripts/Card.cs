using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int Attack;
    public int Health;
    public string Description;
    public string Name;

    public Player owner;

    public bool IsOnBoard { get; set; } = false;

    private TextMeshProUGUI textMesh;

    public Card(string name, int attack, int health, string description)
    {
        Attack = attack;
        Health = health;
        Name = name;
        Description = description;
    }

    public abstract void OnAttack();

    private void Start()
    {
        CreateTextMesh();
    }

    private void OnMouseDown()
    {
        return;
        if (!Board._instance.AddToBoard(this)) 
        {
            if (!AttackCursor.IsCursorEnabled && owner.OwnedByLocal())
            {
                AttackCursor.SetCursorStatus(true);
                Instantiate(CardManager.GetAttackCursor());
            }
            else 
            {
                if (!owner.OwnedByLocal()) 
                {
                    AttackCursor.SetCursorStatus(false);
                    Debug.Log($"{Name} attacked !");
                }
            }
        }
    }

    private void CreateTextMesh() 
    {
        GameObject canvas = Instantiate(CardManager.GetCanvasPrefab(), transform);
        canvas.GetComponent<Canvas>().sortingOrder = 1;

        GameObject textObject = canvas.transform.Find("power_text").gameObject;
        textMesh = textObject.GetComponent<TextMeshProUGUI>();

        textMesh.SetText(Name);
    }

    private bool shouldAddToBoardAfterDrag = false;

    private void OnMouseDrag() 
    {
        if (IsOnBoard)
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        pos = new Vector2(pos.x, pos.y);

        bool shouldSnap = pos.y > -1f;

        if (shouldSnap) 
        {
            Vector2 newPos = Board._instance.GetLastPosition();
            if(newPos != Vector2.zero) 
            {
                transform.position = newPos;
                shouldAddToBoardAfterDrag = true;
            }
        }
        else 
        {
            transform.position = pos;
            shouldAddToBoardAfterDrag = false;
        }
    }

    private void OnMouseUp() 
    {
        if (shouldAddToBoardAfterDrag) 
        {
            Board._instance.AddToBoard(this);
        }
    }

    public void ShowInfo()
    {
        textMesh.SetText(owner.Name);
    }
}