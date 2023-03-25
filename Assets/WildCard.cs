using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildCard : MonoBehaviour
{
    public int Attack;
    public int Health;

    public List<Buff> Buffs = new List<Buff>();

    public void AddBuff(Buff buff) 
    {
        Buffs.Add(buff);
    }
    private void OnMouseDown()
    {
        Map._istance.AddCardToMap(this);
    }
}

public class Buff 
{
    public int AttackBuff;
    public int HealthBuff;
}