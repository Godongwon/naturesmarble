using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeOverTabs : MonoBehaviour
{

    public List<GameObject> Player1Prefabs = new List<GameObject>();
    public List<GameObject> Player2Prefabs = new List<GameObject>();
    public List<GameObject> Player3Prefabs = new List<GameObject>();

    public List<GameObject> curPlayerPrefabs = new List<GameObject>();



    public GameObject takePan;
    public GameObject[] Players;
    public GameObject curPalyer;
    public GameObject diceControl;
    public bool Level1_Click;
    public bool Level2_Click;
    public bool Level3_Click;

    public int BluidingCount;

    public GameObject moneyDis;

    public Animator ani;

    private void Awake()
    {
        diceControl = GameObject.Find("Dices");
        ani = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {

        Level1_Click = false;
        Level2_Click = false;
        Level3_Click = false;
        ani.SetBool("Enable", true);

    }
    private void Update()
    {
        if (!isanimation("EnableTakepan"))
        {
            ani.SetBool("Enable", false);

        }
    }
    bool isanimation(string name)
    {
        return isPlay() && ani.GetCurrentAnimatorStateInfo(0).IsName(name);
    }
    bool isPlay()
    {
        
        return ani.GetCurrentAnimatorStateInfo(0).length > ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    void SelectBluidingCount()
    {
        Level1_Click = GameObject.Find("Level1").GetComponent<BildingBuy>().mouseClick;
        Level2_Click = GameObject.Find("Level2").GetComponent<BildingBuy>().mouseClick;
        Level3_Click = GameObject.Find("Level3").GetComponent<BildingBuy>().mouseClick;
        if (Level1_Click && Level2_Click && Level3_Click)
        {
            BluidingCount = 3;
        }
        else if (Level1_Click && Level2_Click)
        {
            BluidingCount = 2;
        }
        else if (Level1_Click)
        {
            BluidingCount = 1;
        }
        else
        {
            BluidingCount = 0;
        }
    }
    public void selectcount(int count)
    {
        if (count == 2)
        {
            Level1_Click = true;
            Level2_Click = true;
            Level3_Click = false;

        }
        else if (count == 1)
        {
            Level1_Click = true;
            Level2_Click = false;
            Level3_Click = false;
        }
        else if (count == 0)
        {
            Level1_Click = false;
            Level2_Click = false;
            Level3_Click = false;
        }
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
        if (curPalyer.transform.tag == "Player1")
        {
            for (int i = 0; i < Player1Prefabs.Count; i++)
            {
                curPlayerPrefabs.Add(Player1Prefabs[i]);
            }
        }
        else if (curPalyer.transform.tag == "Player2")
        {
            for (int i = 0; i < Player2Prefabs.Count; i++)
            {
                curPlayerPrefabs.Add(Player2Prefabs[i]);
            }
        }
        else if (curPalyer.transform.tag == "Player3")
        {
            for (int i = 0; i < Player3Prefabs.Count; i++)
            {
                curPlayerPrefabs.Add(Player3Prefabs[i]);
            }
        }
    }


    void bliding(GameObject curplayway, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bliding = (GameObject)Instantiate(curPlayerPrefabs[i]);
            bliding.transform.parent = curplayway.transform;
            if (curplayway.transform.parent.name == "OneLine")
            {
                if (i == 0)
                {
                    bliding.transform.localPosition = new Vector3(-0.3f, 1.5f, -0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);
                }
                else if (i == 1)
                {
                    bliding.transform.localPosition = new Vector3(0f, 1.0f, -0.3f);
                    // bliding.transform.localScale = new Vector3(0.3f, 2.6f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);


                }
                else if (i == 2)
                {
                    bliding.transform.localPosition = new Vector3(0.3f, 1.0f, -0.3f);
                    //bliding.transform.localScale = new Vector3(0.3f, 3.0f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
            }
            else if (curplayway.transform.parent.name == "TwoLine")
            {
                if (i == 0)
                {
                    bliding.transform.localPosition = new Vector3(-0.3f, 1.5f, 0.3f);
                    // bliding.transform.localScale = new Vector3(0.3f, 1.8f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 1)
                {
                    bliding.transform.localPosition = new Vector3(-0.3f, 1.0f, 0f);
                    //bliding.transform.localScale = new Vector3(0.3f, 2.6f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 2)
                {
                    bliding.transform.localPosition = new Vector3(-0.3f, 1.0f, -0.3f);
                    //bliding.transform.localScale = new Vector3(0.3f, 3.0f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                bliding.transform.Rotate(new Vector3(0, 90.0f, 0));
            }
            else if (curplayway.transform.parent.name == "ThreeLine")
            {
                if (i == 0)
                {
                    bliding.transform.localPosition = new Vector3(0.3f, 1.5f, 0.3f);
                    //bliding.transform.localScale = new Vector3(0.3f, 1.8f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 1)
                {
                    bliding.transform.localPosition = new Vector3(0f, 1.5f, 0.3f);
                    // bliding.transform.localScale = new Vector3(0.3f, 2.6f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 2)
                {
                    bliding.transform.localPosition = new Vector3(-0.3f, 1.5f, 0.3f);
                    // bliding.transform.localScale = new Vector3(0.3f, 3.0f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                bliding.transform.Rotate(new Vector3(0, 180.0f, 0));
            }
            else if (curplayway.transform.parent.name == "FourLine")
            {
                if (i == 0)
                {
                    bliding.transform.localPosition = new Vector3(0.3f, 1.0f, -0.3f);
                    //bliding.transform.localScale = new Vector3(0.3f, 1.8f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 1)
                {
                    bliding.transform.localPosition = new Vector3(0.3f, 1.0f, 0);
                    //bliding.transform.localScale = new Vector3(0.3f, 2.6f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                else if (i == 2)
                {
                    bliding.transform.localPosition = new Vector3(0.3f, 1.0f, 0.3f);
                    //bliding.transform.localScale = new Vector3(0.3f, 3.0f, 0.3f);
                    bliding.transform.localScale = new Vector3(0.04f, 0.7f, 0.04f);

                }
                bliding.transform.Rotate(new Vector3(0, 270.0f, 0));
            }





        }
    }


    public void BuyClick()
    {
        bool remover = false;
        selectPlayer();
        if (!moneyDis.GetComponent<Money>().istravel)
        {
            SelectBluidingCount();
           
        }
        curPalyer.GetComponent<PlayerControl>().PlayerGiveWay.Add(curPalyer.GetComponent<PlayerControl>().lastTest);
        GameObject curPlayerWay =
            curPalyer.GetComponent<PlayerControl>().PlayerGiveWay[curPalyer.GetComponent<PlayerControl>().PlayerGiveWay.Count - 1];

        if (curPlayerWay.transform.parent.name == "OneLine" ||
            curPlayerWay.transform.parent.name == "TwoLine" ||
            curPlayerWay.transform.parent.name == "ThreeLine" ||
            curPlayerWay.transform.parent.name == "FourLine")
        {
            if (BluidingCount != 0)
            {
                bliding(curPlayerWay, BluidingCount);
                curPalyer.GetComponent<PlayerControl>().money -= moneyDis.GetComponent<Money>().price;
                curPlayerWay.tag = curPalyer.tag;
                curPlayerWay.GetComponent<wayInfo>().blidingCount = BluidingCount;
                BluidingCount = 0;
            }
            else
            {
                remover = true;
            }

        }
        else if (curPlayerWay.transform.parent.name == "Travel")
        {
            curPlayerWay.tag = curPalyer.tag;
            GameObject bliding = (GameObject)Instantiate(curPlayerPrefabs[3]);
            bliding.transform.parent = curPlayerWay.transform;
            bliding.transform.localPosition = new Vector3(0, 2, 0);
            bliding.transform.localScale = new Vector3(10, 20, 10);
            curPalyer.GetComponent<PlayerControl>().money -= 2000;
            moneyDis.GetComponent<Money>().istravel = false;
        }
       

        if (remover)
        {
            curPalyer.GetComponent<PlayerControl>().PlayerGiveWay.Remove(curPlayerWay);
            Debug.Log(curPlayerWay.name + "삭제");

        }

        curPlayerPrefabs.Clear();
        diceControl.GetComponent<DiceOff>().DiceDisOn = false;
        curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
        takePan.SetActive(false);




    }
    public void ExitClick()
    {
        selectPlayer();
        diceControl.GetComponent<DiceOff>().DiceDisOn = false;
        curPlayerPrefabs.Clear();
        curPalyer.GetComponent<PlayerControl>().myturnEnd = true;
        takePan.SetActive(false);
    }
}
