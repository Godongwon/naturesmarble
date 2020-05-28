using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    public List<GameObject> Players=new List<GameObject>();
    int count = 0;
    public GameObject Player;
    public int PlayernonDienum;

    public GameObject GameExitpan;
    public GameObject CardEffect;
    public GameObject sound;
    AudioSource AudioSource;

    GameObject curplayer()
    {

        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i].GetComponent<PlayerControl>().myTurn)
            {
                Player = Players[i];
                break;
            }
        }
        PlayernonDienum = Players.Count;
        return Player;
    }
    private void Awake()
    {
        GameManager.instance = this;
        GameExitpan.SetActive(false);
        CardEffect.SetActive(false);
        sound = GameObject.FindGameObjectWithTag("Sound");
        AudioSource = gameObject.GetComponent<AudioSource>();
        for (int i = 1; i < 4; i++)
        {
            GameObject pr = GameObject.FindGameObjectWithTag("Player" + i.ToString());
            if (pr != null)
            {
                Players.Add(pr);
            }
        }
    }
    void Update()
    {

        if (Players.Count > 1)
        {
            SelectCurPlayer();

        }
        else
        {
            GameExit();

        }
       
    }
    public static GameManager instansce
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    

    void SelectCurPlayer()
    {
        
        curplayer();






        if (Player.GetComponent<PlayerControl>().PlayerDie)
        {
            playertrunoff();
            PlayerturnControl();
            Player.GetComponent<PlayerControl>().myTurn = true;
            Player.GetComponent<PlayerControl>().myturnEnd = false;
        }

        else if (Player.GetComponent<PlayerControl>().myturnEnd)
        {

            if(Player.transform.tag=="Player1")//&&!Player.GetComponent<PlayerControl>().PlayerDie)
            {
                
                if (!Player.GetComponent<PlayerControl>().DiceDubble)
                {

                    Player.GetComponent<PlayerControl>().myTurn = false;
                    playertrunoff();

                    Player.GetComponent<PlayerControl>().myTurn = true;
                    Player.GetComponent<PlayerControl>().myturnEnd = false;
                }
                else
                {

                    if (!Player.GetComponent<PlayerControl>().PlayerDie)
                    {
                        Player.GetComponent<PlayerControl>().myTurn = true;
                        Player.GetComponent<PlayerControl>().myturnEnd = false;
                    }
                    else
                    {
                        playertrunoff();

                    }

                }
            }
            else if(Player.transform.tag == "Player2")//&& !Player.GetComponent<PlayerControl>().PlayerDie)
            {
                
                if (!Player.GetComponent<PlayerControl>().DiceDubble)
                {
                   
                        Player.GetComponent<PlayerControl>().myTurn = false;
                        playertrunoff();
                        Player.GetComponent<PlayerControl>().myTurn = true;
                        Player.GetComponent<PlayerControl>().myturnEnd = false;
                 
                }
                else
                {
                    if (!Player.GetComponent<PlayerControl>().PlayerDie)
                    {
                        Player.GetComponent<PlayerControl>().myTurn = true;
                        Player.GetComponent<PlayerControl>().myturnEnd = false;
                    }
                    else
                    {
                        playertrunoff();

                    }
                }
            }
            else if(Player.transform.tag == "Player3")//&& !Player.GetComponent<PlayerControl>().PlayerDie)
            {
                if (!Player.GetComponent<PlayerControl>().DiceDubble)
                {
                    Player.GetComponent<PlayerControl>().myTurn = false;
                    
                    playertrunoff();
                    Player.GetComponent<PlayerControl>().myTurn = true;
                    Player.GetComponent<PlayerControl>().myturnEnd = false;
                }
                else
                {
                    if (!Player.GetComponent<PlayerControl>().PlayerDie)
                    {
                        Player.GetComponent<PlayerControl>().myTurn = true;
                        Player.GetComponent<PlayerControl>().myturnEnd = false;
                    }
                    else
                    {
                        playertrunoff();

                    }
                }

            }
           

        }

    }
    void PlayerturnControl()
    {
        for(int i=0;i<Players.Count;i++)
        {
            if(Players[i].GetComponent<PlayerControl>().PlayerDie)
            {
                Debug.Log("여기다.");
               if(Players[i].GetComponent<PlayerControl>().myTurn)
               {
                   Players[i].GetComponent<PlayerControl>().myturnEnd = true;
                   Players[i].GetComponent<PlayerControl>().myTurn = false;
               }
                Players.Remove(Players[i]);
               // Player = null;
                break;
            }
        }

        
    }

    private GameObject playertrunoff()
    {
       
        for (int i = 0; i < Players.Count; i++)
        {
            Debug.Log(Player.transform.name);
            AudioSource.PlayOneShot(sound.GetComponent<SoundManager>().trunoff);

            if (Players[i].transform.name == Player.transform.name)
            {
                if (i+1 == Players.Count)
                {
                    Player = Players[0];
                }
                else
                {
                    Player = Players[i + 1];
                }

                break;
            }
        }
        Debug.Log(Player.transform.name);

        return Player;
    }
    public void PlayerDIe(GameObject curplayer)
    {
        
        if (curplayer != null)
        {
            if (curplayer.GetComponent<PlayerControl>().money <= 0)
            {
                Debug.Log("PlayerDIe");
                curplayer.GetComponent<PlayerControl>().money = 0;
                for (int i = 0; i < curplayer.GetComponent<PlayerControl>().PlayerGiveWay.Count; i++)
                {
                    curplayer.GetComponent<PlayerControl>().PlayerGiveWay[i].tag = "Untagged";
                    if (curplayer.GetComponent<PlayerControl>().PlayerGiveWay[i].transform.childCount > 0)
                    {
                        for (int j = 1; j < curplayer.GetComponent<PlayerControl>().PlayerGiveWay[i].transform.childCount; j++)
                        {
                            Destroy(curplayer.GetComponent<PlayerControl>().PlayerGiveWay[i].transform.GetChild(j).gameObject);
                        }
                    }
                }
                curplayer.GetComponent<PlayerControl>().PlayerDie = true;
                curplayer.SetActive(false);

                //PlayerturnControl();
                //
                //Player.GetComponent<PlayerControl>().myTurn = true;
                //Player.GetComponent<PlayerControl>().myturnEnd = false;

            }
        }
    }
    void GameExit()
    {
        GameExitpan.SetActive(true);
        GameExitpan.GetComponent<TextMeshProUGUI>().text = Players[0].transform.tag.ToString() + "!!Victory!!";
        CardEffect.SetActive(true);
    }
}
