using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text priceDis;
    public int price;

    public bool Level1_Click;
    public bool Level2_Click;
    public bool Level3_Click;
    public bool istravel;
    void Start()
    {
        priceDis = gameObject.transform.GetChild(0).GetComponent<Text>();

    }
    void Update()
    {
        if (istravel)
        {
            price = 2000;
        }
        else
        {


            Level1_Click = GameObject.Find("Level1").GetComponent<BildingBuy>().mouseClick;
            Level2_Click = GameObject.Find("Level2").GetComponent<BildingBuy>().mouseClick;
            Level3_Click = GameObject.Find("Level3").GetComponent<BildingBuy>().mouseClick;

            if (Level1_Click && Level2_Click && Level3_Click)
            {
                price = 1000;
            }
            else if (Level1_Click && Level2_Click)
            {
                price = 700;
            }
            else if (Level1_Click)
            {
                price = 400;
            }

            else
            {
                price = 0;
            }
        }
        priceDis.text = "가격 : "+price.ToString();

    }
}
