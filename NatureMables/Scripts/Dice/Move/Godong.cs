using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Godong : MonoBehaviour
{
    public List<GameObject> playerPathCopy=new List<GameObject>();
    public GameObject[] Players;
    public GameObject curPlayer;
  

    public GameObject[] wayPointRotate;
    public GameObject Camera;

    public float speed=15.0f;
    public bool moving;

    public bool turn = false;

    public void Playertrun(GameObject go,GameObject tile)
    {
        if(turn)
        {
            if(tile.transform.name== wayPointRotate[0].transform.name)
            {
                //90
                go.transform.localEulerAngles=new Vector3(0, 90.0f, 0);
                //go.transform.localRotation=Quaternion.Lerp(go.transform.localRotation,Quaternion.Euler(0,90.0f,0), 10 * Time.deltaTime);
                if (go.transform.localEulerAngles.y == 90.0f)
                    turn = false;
                
            }
            else if(tile.transform.name == wayPointRotate[1].transform.name)
            {
                //180
                go.transform.localEulerAngles=new Vector3(0, 180.0f, 0);
                //go.transform.localRotation=Quaternion.Lerp(go.transform.localRotation, Quaternion.Euler(0, 180.0f, 0), 3 * Time.deltaTime);
                if(go.transform.localEulerAngles.y==180.0f)
                turn = false;

            }
            else if(tile.transform.name == wayPointRotate[2].transform.name)
            {
                //170
                go.transform.localEulerAngles= new Vector3(0, 270.0f, 0);
                //go.transform.localRotation=Quaternion.Lerp(go.transform.localRotation, Quaternion.Euler(0, 270.0f, 0), 3 * Time.deltaTime);
                if (go.transform.localEulerAngles.y == 270.0f)
                    turn = false;
                
            }
            else if (tile.transform.name == wayPointRotate[3].transform.name)
            {
                //0
                go.transform.localEulerAngles=new Vector3(0, 0.0f, 0);
                //go.transform.localRotation=Quaternion.Lerp(go.transform.localRotation, Quaternion.Euler(0, 0.0f, 0), 0.5f * Time.deltaTime);
                if (go.transform.localEulerAngles.y ==0.0f)
                    turn = false;
                
            }
        }
    }



    public void selectPlayer()
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

    public void pathCopy()
    {
        selectPlayer();
        playerPathCopy = curPlayer.GetComponent<PlayerControl>().paths;
    }
    // , 움직일 칸 수 
    public void ObjectMove(int movenum)
    {
       // float time = 0;
        if (movenum == playerPathCopy.Count)
        {
            
            curPlayer.GetComponent<PlayerControl>().cameraMove = false;
            curPlayer.GetComponent<PlayerControl>().movemod = false;
            time = 0;
            moving = false;
            curPlayer = null;
        }
        else
        {
            curPlayer.GetComponent<PlayerControl>().cameraMove = true;

           if(Camera.GetComponent<CameraMove>().playermover)
            {

            StartCoroutine(MoverDelay(curPlayer, movenum));
            }
            

        }
       
       
    }
    IEnumerator MoverDelay(GameObject ob,int i)
    {
        
        if (i < playerPathCopy.Count)
        {
            
            ob.transform.localPosition = Vector3.MoveTowards(ob.transform.localPosition, 
                                                            playerPathCopy[i].transform.position,
                                                            speed * (Time.deltaTime*2));
            if(ob.transform.localPosition != playerPathCopy[i].transform.position)
            {
                ob.GetComponent<AudioSource>().Play();

            }
            
            moving = true;

            for(int j=0;j< wayPointRotate.Length;j++)
            {
                if(wayPointRotate[j].transform.name == playerPathCopy[i].transform.name
                    && ob.transform.localPosition== playerPathCopy[i].transform.position)
                {
                    turn = true;
                   
                }
            }
             Playertrun(ob, playerPathCopy[i]);




            

        }
       


        yield return new WaitForSeconds(1.0f);
       





    }
    int i = 0;
    float time = 0;
    public int moveNumerCon(int max)
    {
       
        
        if(curPlayer.transform.localPosition != playerPathCopy[i].transform.position)
        {
            curPlayer.GetComponent<PlayerControl>().ani.SetBool("Move", true);
            
            return i;
        }
        else
        {
            
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                if (i + 1 < max)
                {
                    i += 1;
                    time = 0;

                }
                else
                {
                    i = max;
                    time = 0;
                 
                }
            }

           
            return i;
        }
    }
    public void setI()
    {
       i = 0;
    }



}
