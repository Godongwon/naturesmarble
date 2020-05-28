using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceOff : MonoBehaviour
{
    public GameObject dice1;
    public GameObject dice2;

    public GameObject[] Players;
    public GameObject curPlayer;

    public bool DiceDisOn=false;

    public int dice1Num;
    public int dice2Num;
    float time;

    void Awake()
    {
        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");

    }

    void Update()
    {
        dice1Num = dice1.GetComponent<DiceControl>().diceNum;
        dice2Num = dice2.GetComponent<DiceControl>().diceNum;
 
        if (dice1Num!=0&&dice2Num!=0)
        {
            time += Time.deltaTime;
            
       
            if (time > 1.5f)
            {
                
                selectcurPlayer();
                curPlayer.GetComponent<PlayerControl>().DicenumChange();
                dice1.GetComponent<DiceControl>().offDice();
                dice2.GetComponent<DiceControl>().offDice();
                DiceDisOn = true;
                time = 0;

            }
            
            
        }
        
    }

    void selectcurPlayer()
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
