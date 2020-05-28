using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    public List<GameObject> WayPoint = new List<GameObject>();
    public List<GameObject> PlayerGiveWay = new List<GameObject>();
    public  int lastIndex;
    public List<GameObject> paths = new List<GameObject>();
    public List<GameObject> Cardpaths = new List<GameObject>();

    public List<GameObject> last = new List<GameObject>();
    public GameObject lastTest;
    public GameObject Mover;

    public int count = 0;
    public GameObject RayCastCtrol;

    public int diceSum;
    

    public int Movenum = 0;
    public bool myTurn = true;
    public bool pathset = false;
    public GameObject Dice1;
    public GameObject Dice2;
    public GameObject Dice1Check;
    public GameObject Dice2Check;

    public bool myturnEnd=false;

    public bool cameraMove = false;

    public bool DiceDubble;


    public bool throwDice;
    public Animator ani;

    public bool movemod;
    public Text PlayermoneyDis;
    public GameObject PlayerDis;

    public int money;

    public bool cardAngle=false;
    public bool cardpriceNone=false;

    public bool PlayerDie = false;

    public GameObject mytrunDis;
    public GameObject angleCardimg;
    public GameObject PriceCardimg;

    public bool GiveMoney=false;

    private void Awake()
    {
        lastIndex = 0;
        movemod = false;
        money = 3000;
        DiceDubble = false;
        mytrunDis.SetActive(false);
        angleCardimg.SetActive(false);
        PriceCardimg.SetActive(false);
        PlayerDis.SetActive(true);
    }
    void Start()
    {
        Mover = GameObject.Find("Mover");
       
        WayPoint.Clear();
        for (int i = 1; i < 33; i++)
        {
            WayPoint.Add(GameObject.Find("WayPoint" + i.ToString()));
        }
       
        
        gameObject.transform.position = WayPoint[0].transform.position;
        ani = GetComponent<Animator>();
        throwDice = false;

    }
    public void DiceThrow()
    {
        throwDice = true;
    }
    public void NonDiceThrow()
    {
        throwDice = false ;
    }
    public void DicenumChange()
    {
       
      int Dice1Num = Dice1.GetComponent<DiceControl>().diceNum;
      int Dice2Num = Dice2.GetComponent<DiceControl>().diceNum;
        diceSum= Dice1Num + Dice2Num;
        Movenum = Dice1Num + Dice2Num;
      if (Dice1.GetComponent<DiceControl>().diceNum == Dice2.GetComponent<DiceControl>().diceNum)
      {
          DiceDubble = true;
      }
       else
       {
           DiceDubble = false;

       }



    }
    void Update()
    {
        if (myTurn && !myturnEnd)
        {

            if (Movenum != 0 && !pathset)
            {
                path();
            }


            if (movemod)
            {
                Move();
            }
            else
            {
                Mover.GetComponent<Godong>().setI();
                Mover.GetComponent<Godong>().playerPathCopy.Clear();
                Movenum = 0;
                pathset = false;
            }
        }
        if (!PlayerDie)
        {
            PlayermoneyDis.text = "Money : " + money;
        }
        else
        {
            PlayerDis.SetActive(false);

        }
        if (myTurn)
        {
            mytrunDis.SetActive(true);
        }
        else
        {
            mytrunDis.SetActive(false);
        }

        if (cardAngle)
        {
            angleCardimg.SetActive(true);
        }
        else
        {
            angleCardimg.SetActive(false);
        }

        if (cardpriceNone)
        {
            PriceCardimg.SetActive(true);
        }
        else
        {
            PriceCardimg.SetActive(false);
        }

    }
    public void endding()
    {
        ani.SetBool("Move", false);

        lastTest=paths[paths.Count - 1].transform.parent.gameObject;
        RayCastCtrol.SetActive(true);
    }
    

    public void path()
    {
        if(!pathset)
        {
            count++;
            if (paths.Count != 0)
            {
                Movenum = 0;
                paths.Clear();
            }

            int pathnum = Movenum;
            if (lastIndex == 32)
            {
                paths.Add(WayPoint[0]);
                lastIndex = 0;
            }
            else
            {
                paths.Add(WayPoint[lastIndex]);

            }
            for (int i = 1; i < Movenum; i++)
            {
               
                if (paths[paths.Count-1].name == "WayPoint32"&&i+1==Movenum)
                {
                    
                    lastIndex = 1;
                    Movenum -=i;
                    paths.Add(WayPoint[0]);
                    
                
                }
                else
                {
                
                    if (paths[paths.Count - 1].name == "WayPoint32"&&count>1&& paths[0].name != "WayPoint1")
                    {
                        Movenum -= i;
                        i = 0;
                        for(;i<Movenum;i++)
                        {

                        paths.Add(WayPoint[i]);
                        }

                        break;
                    }
            
                    else
                    {
                    paths.Add(WayPoint[lastIndex+i]);
                    }
                }
            }
             lastIndex = paths.Count + lastIndex;
            if(lastIndex>32)
            {
                lastIndex -= 32;
            }

            if(paths[paths.Count - 1].name == "WayPoint1")
            {
                lastIndex = 0;

            }
            else if(paths[paths.Count - 1].name == "WayPoint32")
            {
                lastIndex = 32;
            }
           for(int i=0;i<paths.Count; i++)
            {
                if(paths[i].name== "WayPoint1")
                {
                    GiveMoney = true;
                    break;
                }
            }
            
            pathset = true;
            movemod = true;
        }
        if (count == 1)
        {
            paths.Add(WayPoint[lastIndex]);
            lastIndex += 1;
            Movenum += 1;
        }
    }
    
    #region
    //public void start()
    //{
    //
    //
    //
    //    for (int i = 0; i < 32; i++)
    //    { 
    //
    //            if (Cardpaths[Cardpaths.Count - 1].name == "WayPoint32"&& Cardpaths.Count != 0)
    //            {
    //            
    //                paths.Add(WayPoint[0]);
    //                
    //                break;
    //            }
    //            else
    //            {
    //                Cardpaths.Add(WayPoint[lastIndex+i]);
    //            }
    //        }
    //
    //        Movenum = Cardpaths.Count;
    //        Mover.GetComponent<Godong>().pathCopy();
    //        Mover.GetComponent<Godong>().ObjectMove(Mover.GetComponent<Godong>().moveNumerCon(Cardpaths.Count));
    //
    //    
    //   
    //}
    //public void train()
    //{
    //    //시작지점으로
    //
    //        for (int i = 0; i < 32; i++)
    //        {
    //             
    //            if (paths[Cardpaths.Count - 1].name == "WayPoint25"&& paths.Count!=0)
    //            {
    //
    //                lastIndex = 25;
    //                break;
    //            }
    //            else
    //            {
    //            paths.Add(WayPoint[lastIndex+i]);
    //
    //            }
    //
    //        }
    //    Movenum = paths.Count;
    //    Mover.GetComponent<Godong>().pathCopy();
    //    Mover.GetComponent<Godong>().ObjectMove(Mover.GetComponent<Godong>().moveNumerCon(paths.Count));
    //    if (!Mover.GetComponent<Godong>().moving && !movemod)
    //    {
    //        endding();
    //    }
    //
    //
    //}
    #endregion

    public void Move()
    {
       
        
        Mover.GetComponent<Godong>().pathCopy();
     
        Mover.GetComponent<Godong>().ObjectMove(Mover.GetComponent<Godong>().moveNumerCon(paths.Count));
        if (!Mover.GetComponent<Godong>().moving && !movemod)
        {
            endding();
        }
       
    }

    
}
  



