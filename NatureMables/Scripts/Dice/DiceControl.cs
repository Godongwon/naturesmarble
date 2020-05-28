using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceControl : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 diceVelocity;


    public  int diceNum=0;
    public Text NumDisplay;
    public float power;

    float dirX;
    float dirY;
    float dirZ;

    AudioSource diceSound;

    void Start()
    {
        diceSound = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        this.power = GameObject.Find("DiceButton").GetComponent<ButtonControl>().power;
        gameObject.SetActive(false);
    }
    private void Update()
    {
        diceVelocity = rb.velocity;
        NumDisplay.text = gameObject.transform.name+ " : "+diceNum.ToString();
    }
    public void onDice()
    {
        gameObject.SetActive(true);
    }
    public void offDice()
    {
        diceNum = 0;
        gameObject.SetActive(false);

    }
    public void DiceTrow()
    {
        dirX = Random.Range(2000, 3500);
        dirY = Random.Range(2000, 3500);
        dirZ = Random.Range(2000, 3500);
       //transform.rotation = Quaternion.identity;

        if (transform.name == "Dice1")
        {
            transform.position = new Vector3(-2,10, 0);
        }
       else
        {
            transform.position = new Vector3(2, 10, 0);
        }
       
        rb.AddForce(transform.up *power*100);
    
        rb.AddTorque(dirX, dirY, dirZ);
    }
    private void OnCollisionEnter(Collision coll)
    {
        diceSound.Play();
    }
}
