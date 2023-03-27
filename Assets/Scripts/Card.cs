using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvasPrefab;

    public List<Buff> Buffs = new List<Buff>();

    public int Attack;
    public int Health;
    public string Description;

    public void Start() 
    { 
        CreateTextMesh();
    }

    public Card(int attack, int health, string description)
    {
        Attack = attack;
        Health = health;

        Description = description;
    }

    public void AddBuff(Buff buff) 
    {
        Buffs.Add(buff);
    }

    private void OnMouseDown()
    {
        Map._instance.CardClicked(this);
    }

    private TextMeshProUGUI textMesh;

    private void CreateTextMesh() 
    {
        GameObject canvas = Instantiate(_canvasPrefab, transform);
        GameObject textObject = canvas.transform.Find("power_text").gameObject;
        textMesh = textObject.GetComponent<TextMeshProUGUI>();
    }



    public void ShowInfo()
    {
        textMesh.SetText(Description);
    }
}

public class Buff 
{
    public int AttackBuff;
    public int HealthBuff;
}