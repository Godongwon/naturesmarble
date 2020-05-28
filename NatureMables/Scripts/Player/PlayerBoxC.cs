using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoxC : MonoBehaviour
{

    public GameObject[] Players;
    public GameObject curPalyer;
    public GameObject takePan;
    public GameObject Cardpan;
    public GameObject[] level;
    public GameObject trevel;

    public GameObject money;
    public GameObject Payplayer;
    public GameObject diceControl;
    public int travelpass = 2000;
    public int pass = 1000;

    public RaycastHit hit;
    public GameObject PlayerCard;


    private void Awake()
    {
        //Cardpan= GameObject.Find("Card");
        PlayerCard.SetActive(false);
        takePan = GameObject.FindGameObjectWithTag("Take");
        takePan.SetActive(false);
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].GetComponent<PlayerControl>().RayCastCtrol = gameObject;
        }
        gameObject.SetActive(false);
        diceControl = GameObject.Find("Dices");
    }



    void selectPlayer()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].GetComponent<PlayerControl>().myTurn)
            {
                curPalyer = Players[i];
                break;
            }
        }
    }
    private void OnEnable()
    {

        selectPlayer();

        

        Debug.DrawRay(curPalyer.transform.position, curPalyer.transform.TransformDirection(Vector3.down) * 5);
        if (Physics.Raycast(curPalyer.transform.position, curPalyer.transform.TransformDirection(Vector3.down), out hit, 5.0f))
        {
            Debug.Log(hit.transform.name);
            if (curPalyer.GetComponent<PlayerControl>().lastTest != null)
            {
                if (curPalyer.GetComponent<PlayerControl>().lastTest.transform.name == hit.transform.name)
                {
                    /*
                     경우의 수
                     1. 아무 주인 없는 땅을 밞았을 경우
                     2. 주인이 curplayer지만 건물의 수가 3개가 아닐경우
                     3. curplayer가 남의 땅을 밞았을 경우
                     4. curplayer가 자기 자신의 땅을 밟았을 경우?
                     */

                    if (!(hit.transform.parent.name == "BicFoot" || hit.transform.parent.name == "Chance"))
                    {

                        //1. 아무 주인 없는 땅을 밞았을 경우
                        if (hit.transform.tag == "Untagged")
                        {
                            if (curPalyer.GetComponent<PlayerControl>().money >= 2000)
                            {
                                takePan.SetActive(true);

                                if (hit.transform.parent.name == "Travel")
                                {
                                   
                                        money.GetComponent<Money>().istravel = true;
                                        for (int i = 0; i < level.Length; i++)
                                        {
                                            level[i].SetActive(false);
                                        }
                                        trevel.SetActive(true);
                                    
                                }
                                else
                                {
                                    for (int i = 0; i < level.Length; i++)
                                    {
                                        level[i].SetActive(true);

                                    }
                                    trevel.SetActive(false);
                                }
                            }
                            else
                            {
                                Debug.Log("돈이부족해");
                                curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
                            }
                            diceControl.GetComponent<DiceOff>().DiceDisOn = false;
                            curPalyer = null;
                            gameObject.SetActive(false);
                        }
                        else if (hit.transform.tag == curPalyer.tag )
                        {
                            //2. 주인이 curplayer지만 건물의 수가 3개가 아닐경우
                            if (hit.transform.GetComponent<wayInfo>().blidingCount < 3 && hit.transform.parent.name != "Travel")
                            {
                                takePan.GetComponent<TakeOverTabs>().selectcount(hit.transform.GetComponent<wayInfo>().blidingCount);
                                takePan.SetActive(true);
                               
                                curPalyer = null;
                            }
                            else if(hit.transform.parent.name != "Travel")
                            {
                                curPalyer = null;
                                curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
                            }
                            else
                            {
                                curPalyer = null;
                                curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
                            }
                            diceControl.GetComponent<DiceOff>().DiceDisOn = false;
                            gameObject.SetActive(false);
                        }
                        else if (hit.transform.tag != curPalyer.tag && hit.transform.tag != "Untagged")
                        {
                            
                            if(curPalyer.GetComponent<PlayerControl>().cardAngle||curPalyer.GetComponent<PlayerControl>().cardpriceNone)
                            {
                                PlayerCard.SetActive(true);
                            }
                            else
                            {
                                paymoney(hit);
                                curPalyer = null;
                            }
                            diceControl.GetComponent<DiceOff>().DiceDisOn = false;

                            gameObject.SetActive(false);

                        }
                    }

                    else if (hit.transform.parent.name == "Chance")
                    {
                        Cardpan.SetActive(true);
                        diceControl.GetComponent<DiceOff>().DiceDisOn = false;
                        curPalyer = null;
                        gameObject.SetActive(false);
                    }
                    else 
                    {
                        curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
                        diceControl.GetComponent<DiceOff>().DiceDisOn = false;
                        curPalyer = null;
                        gameObject.SetActive(false);
                    }
                 

                }
            }
        }

    }


    public void usepaymoney(RaycastHit ob)
    {
        if (ob.transform.parent.name == "Travel")
        {

            //2000원을 준다
            curPalyer.GetComponent<PlayerControl>().money -= 1000;
            for (int i = 0; i < Players.Length; i++)
            {
                if (ob.transform.tag == Players[i].tag)
                {
                    Payplayer = Players[i];
                    break;
                }
            }
            Payplayer.GetComponent<PlayerControl>().money += 1000;
            Payplayer = null;
            curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
        }
        else
        {
            curPalyer.GetComponent<PlayerControl>().money -=500;
            for (int i = 0; i < Players.Length; i++)
            {
                if (ob.transform.tag == Players[i].tag)
                {
                    Payplayer = Players[i];
                    break;
                }
            }
            Payplayer.GetComponent<PlayerControl>().money += 500;
            Payplayer = null;
            curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
        }
        GameManager.instance.PlayerDIe(curPalyer);

        gameObject.SetActive(false);
        curPalyer = null;
    }



    public void paymoney(RaycastHit ob)
    {
        if (ob.transform.parent.name == "Travel")
        {

            //2000원을 준다
            curPalyer.GetComponent<PlayerControl>().money -= travelpass;
            for (int i = 0; i < Players.Length; i++)
            {
                if (ob.transform.tag == Players[i].tag)
                {
                    Payplayer = Players[i];
                    break;
                }
            }
            Payplayer.GetComponent<PlayerControl>().money += travelpass;
            Payplayer = null;
            curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
            
        }
        else
        {
            curPalyer.GetComponent<PlayerControl>().money -= pass;
            for (int i = 0; i < Players.Length; i++)
            {
                if (ob.transform.tag == Players[i].tag)
                {
                    Payplayer = Players[i];
                    break;
                }
            }
            Payplayer.GetComponent<PlayerControl>().money += pass;
            Payplayer = null;
            curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
        }
        GameManager.instance.PlayerDIe(curPalyer);
        gameObject.SetActive(false);
        curPalyer = null;
    }
}


   


