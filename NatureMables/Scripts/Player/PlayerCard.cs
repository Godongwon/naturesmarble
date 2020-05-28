using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public Sprite angle;
    public Sprite pricenon;

    public GameObject[] players;
    public GameObject curPlayer;

    bool isangle=false;
    bool isprice=false;

    public GameObject Raycast;

      public GameObject dices;
    
    void selectPlayer()
    {
        for(int i=0;i<players.Length;i++)
        {
            if(players[i].GetComponent<PlayerControl>().myTurn)
            {
                curPlayer = players[i];
                break;
            }
        }
    }

    private void OnEnable()
    {
        selectPlayer();
        if (curPlayer.GetComponent<PlayerControl>().cardAngle&& curPlayer.GetComponent<PlayerControl>().cardpriceNone)
        {
            gameObject.GetComponent<Image>().sprite = angle;
            isangle = true;
        }
        else if(curPlayer.GetComponent<PlayerControl>().cardAngle)
        {
            gameObject.GetComponent<Image>().sprite = angle;
            isangle = true;

        }
        else if(curPlayer.GetComponent<PlayerControl>().cardpriceNone)
        {
            gameObject.GetComponent<Image>().sprite = pricenon;
            isprice = true;
        }
    }

    public void UsingCard()
    {
        if (isangle)
        {
            selectPlayer();
            curPlayer.GetComponent<PlayerControl>().cardAngle = false;
            curPlayer.GetComponent<PlayerControl>().myturnEnd = true;
            curPlayer = null;
            isangle = false;

        }
        else if(isprice)
        {
            selectPlayer();
            curPlayer.GetComponent<PlayerControl>().cardpriceNone = false;
            Raycast.GetComponent<PlayerBoxC>().usepaymoney(Raycast.GetComponent<PlayerBoxC>().hit);
            curPlayer = null;
            isprice = false;
        }
        gameObject.SetActive(false);

       

    }
    public void ExitCard()
    {
        selectPlayer();
        if (isprice) isprice = false;
        if (isangle) isangle = false;
        Raycast.GetComponent<PlayerBoxC>().paymoney(Raycast.GetComponent<PlayerBoxC>().hit);
        gameObject.SetActive(false);
    }
}
