using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public GameObject[] PlayersCameraPos;
    public GameObject curPlayerCameraPos;
    public GameObject[] Players;
    public GameObject curPlayer;
    public Vector3 FirstCameraPosPosition;
    public Vector3 FirstCameraPosRotation;
    public float cameraSpeed;
    public bool playermover = false;


    public GameObject mover;

    private void Awake()
    {
        FirstCameraPosPosition = gameObject.transform.position;
        FirstCameraPosRotation = gameObject.transform.localEulerAngles;
        mover = GameObject.Find("Mover");
    }

    private void Update()
    {
        cameraMove();
        
    }

        void selectCurPlayer()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].GetComponent<PlayerControl>().myTurn)
                {
                    curPlayer = Players[i];
                    break;
                }
            }
        }
        void selectCurPlayerPos()
        {
            for (int i = 0; i < PlayersCameraPos.Length; i++)
            {
                if (curPlayer.transform.tag == PlayersCameraPos[i].tag)
                {
                    curPlayerCameraPos = PlayersCameraPos[i];
                    break;
                }
            }
        }

        void cameraMove()
        {
            selectCurPlayer();
            if (curPlayer != null)
            {
                selectCurPlayerPos();
            }
            if (curPlayer.GetComponent<PlayerControl>().cameraMove)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.localPosition,
                                                                    curPlayerCameraPos.transform.position,
                                                                    cameraSpeed * (Time.deltaTime * 3));
                if (mover.GetComponent<Godong>().turn)
                {
                    gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.localRotation, curPlayerCameraPos.transform.rotation, 10 * (Time.deltaTime));
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.localRotation, curPlayerCameraPos.transform.rotation, 0.8f * (Time.deltaTime));
                }
                if (gameObject.transform.position == curPlayerCameraPos.transform.position) playermover = true;
            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.localPosition,
                                                                    FirstCameraPosPosition,
                                                                    cameraSpeed * (Time.deltaTime * 3));
                gameObject.transform.localEulerAngles = FirstCameraPosRotation;

                playermover = false;
            }
        }
    
}

