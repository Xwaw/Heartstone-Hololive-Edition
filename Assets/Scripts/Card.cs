using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvasPrefab;

    public List<Buff> Buffs = new List<Buff>();

    public int Attack;
    public int Health;

    public void Start() 
    {
        Attack = Mathf.RoundToInt(Random.Range(0f, 10f));
        Health = Mathf.RoundToInt(Random.Range(0f, 10f));
        CreateTextMesh();
    }

    public void AddBuff(Buff buff) 
    {
        Buffs.Add(buff);
    }

    private void OnMouseDown()
    {
        Map._instance.CardClicked(this);
    }

    private void CreateTextMesh() 
    {
        GameObject canvas = Instantiate(_canvasPrefab, transform);
        GameObject textObject = canvas.transform.Find("power_text").gameObject;
        TextMeshProUGUI textMesh = textObject.GetComponent<TextMeshProUGUI>();
        textMesh.SetText($"{Attack}");
    }
}

public class Buff 
{
    public int AttackBuff;
    public int HealthBuff;
}