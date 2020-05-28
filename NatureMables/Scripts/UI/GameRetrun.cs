using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRetrun : MonoBehaviour
{
    public void retrunGameScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
