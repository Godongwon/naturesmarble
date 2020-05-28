using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceNumberDis : MonoBehaviour
{
    public GameObject diceControl;
    public GameObject[] Players;
    public GameObject curPlayer;
    public GameObject disPlay;

    private void Awake()
    {
        //disPlay.SetActive(false);   
        diceControl = GameObject.Find("Dices");
     
    }
    

    void Update()
    {
        SelectPlayer();
        if (diceControl.GetComponent<DiceOff>().DiceDisOn)
        {

            
            disPlay.GetComponent<TextMeshProUGUI>().text=curPlayer.GetComponent<PlayerControl>().diceSum.ToString();
            
        }
        else
        {
          
            disPlay.GetComponent<TextMeshProUGUI>().text = curPlayer.tag.ToString()+" Throw Dice!";
        }

    }
    public void SelectPlayer()
    {
        for(int i=0;i<Players.Length;i++)
        {
            if(Players[i].GetComponent<PlayerControl>().myTurn)
            {
                curPlayer = Players[i];
                break;
            }
        }
    }
}
