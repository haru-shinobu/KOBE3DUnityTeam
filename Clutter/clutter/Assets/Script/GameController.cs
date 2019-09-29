using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //GameObject timeText;
    GameObject ItemText;
    int Item = 3;

    public void GetItem()
    {
        this.Item += 1;
    }
    public void Damage()
    {
    //    this.hart -= 1;
    }
    void Start()
    {
        this.ItemText = GameObject.Find("HaveItem");
    }

    public UnityEngine.UI.Text scoreLabel;
    public void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreLabel.text = "残り"+count.ToString()+"個";

        this.ItemText.GetComponent<Text>().text = "Get "+this.Item.ToString() + " ITem";
    }
}
