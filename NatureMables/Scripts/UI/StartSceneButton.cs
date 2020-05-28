using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    Animator ani;
    AudioSource click;
    public AudioClip MouseclickS;
    private void Awake()
    {
        ani = gameObject.GetComponent<Animator>();
        click = gameObject.GetComponent<AudioSource>();
        MouseclickS = gameObject.GetComponent<AudioSource>().clip;
    }

    public void Enter()
    {
        ani.SetBool("onMouse", true);
    }
    public void Exit()
    {
        ani.SetBool("onMouse", false);

    }

    public void GameStart()
    {
        click.PlayOneShot(MouseclickS); 
        SceneManager.LoadScene("Marble");
    }
#if UNITY_ANDROID
    public void GameExit()
    {
        Application.Quit();
    }
#endif
}
