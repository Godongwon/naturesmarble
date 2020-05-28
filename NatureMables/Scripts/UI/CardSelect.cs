using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelect : MonoBehaviour
{

    public Sprite[] CardImg;
    /*
     * 1. 천사
     * 2. 시작지점으로
     * 3. 기차여행으로
     * 4. 통행료 면제
     */
    public GameObject[] Players;
    public GameObject curPlayer;
    public Animator cardAni;
    public GameObject CardEffect;

    int index;
    void selectCurPlayer()
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

    void cardSelect()
    {
        index = Random.Range(0, CardImg.Length);
    
        gameObject.GetComponent<Image>().sprite = CardImg[index];

    }
    private void Awake()
    {
        CardEffect.SetActive(false);

        gameObject.SetActive(false);
        cardAni = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        cardAni.SetBool("card", true);
        selectCurPlayer();
        cardSelect();
        cardeffect();
        CardEffect.SetActive(true);
    }

    public void Close()
    {
        selectCurPlayer();
        curPlayer.GetComponent<PlayerControl>().myturnEnd = true;
        CardEffect.SetActive(false);
        gameObject.SetActive(false);
        curPlayer = null;

    }
    void cardeffect()
    {
        /*
        * 1. 천사
        * 2. 시작지점으로
        * 3. 기차여행으로
        * 4. 통행료 면제
        */
        switch (index)
        {
            case 0:
                curPlayer.GetComponent<PlayerControl>().cardAngle = true;
                break;
            case 1:
                curPlayer.GetComponent<PlayerControl>().cardpriceNone = true;
                break;

  
        }
    }
}
