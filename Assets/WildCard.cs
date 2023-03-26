using System.Collections.Generic;
using UnityEngine;

public class WildCard : MonoBehaviour
{
    public List<Buff> Buffs = new List<Buff>();

    public int Attack;
    public int Health;

    public void AddBuff(Buff buff) 
    {
        Buffs.Add(buff);
    }

    private void OnMouseDown()
    {
        Map._instance.CardClicked(this);
    }
}

public class Buff 
{
    public int AttackBuff;
    public int HealthBuff;
}