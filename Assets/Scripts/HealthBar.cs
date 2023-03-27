using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private const float MAX_Y_SCALE = 1.5f;

    private const float MaxHealth = 100;

    private float _health = 100f;

    public float Health 
    {
        get => _health; 
        set 
        {
            SetHealth(value);
        }
    }

    public void Damage(float damage) 
    {
        float nextHealth = Health - damage;

        float endScale = nextHealth / MaxHealth * 1.5f;

        if(endScale > MAX_Y_SCALE) {
            endScale = MAX_Y_SCALE;
        }

        transform.localScale = new Vector2(transform.localScale.x, endScale);
        _health = nextHealth;
    }

    public void SetHealth(float health) 
    {
        float endScale = health / MaxHealth * 1.5f;

        if (endScale > MAX_Y_SCALE) {
            endScale = MAX_Y_SCALE;
        }

        transform.localScale = new Vector2(transform.localScale.x, endScale);
        _health = health;
    }
}
