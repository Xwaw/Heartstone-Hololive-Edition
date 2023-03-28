using UnityEngine;

public class AttackCursor : MonoBehaviour
{
    private static AttackCursor _instance;

    public static bool IsCursorEnabled { get; private set; } = false;

    private void Awake() 
    {
        _instance = this; 
    }

    private void Update() 
    {
        if(IsCursorEnabled) 
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector2(pos.x, pos.y);
            transform.position = pos;
        }
    }

    public static void SetCursorStatus(bool state) 
    {
        IsCursorEnabled = state;

        if (state) 
        {
            Cursor.visible = false;
        }

        if (!state && _instance is not null) 
        {
            _instance.transform.position = new Vector2(10000, 10000);
            Cursor.visible = true;
        }
    }
}
