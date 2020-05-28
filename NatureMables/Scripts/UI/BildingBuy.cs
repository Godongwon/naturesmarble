using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BildingBuy : MonoBehaviour
{

    public bool mouseClick;
    public Image Tree;


    void Start()
    {
       
    }
    private void OnEnable()
    {
        Tree = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        Tree.color = new Color(0, 0, 0);
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        mouseClick = false;
    }

    private void Update()
    {
        if (mouseClick)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
            Tree.color = new Color(255, 255, 255);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
            Tree.color = new Color(0, 0, 0);

        }
    }





    public void Down()
    {
        
        mouseClick = !mouseClick;
        if(transform.name=="Level2")
        {
            if(!GameObject.Find("Level1").GetComponent<BildingBuy>().mouseClick)
            {
                mouseClick = false;
            }
        }
        else if(transform.name == "Level3")
        {
            if (!GameObject.Find("Level2").GetComponent<BildingBuy>().mouseClick)
            {
                mouseClick = false;
            }
        }
      
    }


}
