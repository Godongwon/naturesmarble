using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Image FillImage;
    public float power;
    public bool onMouse;
    public bool MouseClick;
    public bool max;
    public GameObject[] Players;
    public GameObject curPlayer;
    public GameObject dice1;
    public GameObject dice2;
    private void Awake()
    {
        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");
       
    }

    public void MouseEnter()
    {
        onMouse = true;
    }
    public void MouseExit()
    {
        onMouse = false;
    }
    public void MouseDown()
    {
        selectPlayer();
        if (onMouse)
        {
            MouseClick = true;
            FillImage.fillAmount = 0.0f;
        }
        curPlayer.GetComponent<PlayerControl>().NonDiceThrow();
       
    }
    public void MouseUp()
    {
        selectPlayer();
        if (MouseClick)
        MouseClick = false;
        power=FillImage.fillAmount*300.0f;
        curPlayer.GetComponent<PlayerControl>().DiceThrow();
        dice1.GetComponent<DiceControl>().diceNum = 0;
        dice2.GetComponent<DiceControl>().diceNum = 0;
        dice1.GetComponent<DiceControl>().onDice();
        dice2.GetComponent<DiceControl>().onDice();

        GameObject.Find("Mover").GetComponent<Godong>().selectPlayer();
    }
    void selectPlayer()
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
    private void Update()
    {
        if(MouseClick)
        {

            
            if(FillImage.fillAmount>=1.0f)
            {
                max = true;
    
            }
            if (!max)
            {
                FillImage.fillAmount += Time.deltaTime * 2 / 1.0f;
          

            }
            else
            {
                FillImage.fillAmount -= Time.deltaTime * 2 / 1.0f;
                if (FillImage.fillAmount <= 0.0f)
                {
                    max = false;

                }
            }
            

        }
       
    }


}

