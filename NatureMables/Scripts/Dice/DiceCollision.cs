using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCollision : MonoBehaviour
{
    public GameObject dice;
    Vector3 DiceVelocity;


    
    private void FixedUpdate()
    {
        DiceVelocity = dice.GetComponent<DiceControl>().diceVelocity;
     
    
    }

    private void OnTriggerStay(Collider coll)
    {
      
            if (coll.gameObject.tag == dice.tag)
            {
                if (DiceVelocity.x == 0.0f && DiceVelocity.y == 0.0f && DiceVelocity.z == 0.0f)
                {

                switch (coll.gameObject.name)
                {
                    case "Side1":
                        dice.GetComponent<DiceControl>().diceNum = 6;
                        break;
                    case "Side2":
                        dice.GetComponent<DiceControl>().diceNum = 5;
                        break;
                    case "Side3":
                        dice.GetComponent<DiceControl>().diceNum = 4;
                        break;
                    case "Side4":
                        dice.GetComponent<DiceControl>().diceNum = 3;
                        break;
                    case "Side5":
                        dice.GetComponent<DiceControl>().diceNum = 2;
                        break;
                    case "Side6":
                        dice.GetComponent<DiceControl>().diceNum = 1;
                        break;
                }
            }
                else{
                    dice.GetComponent<DiceControl>().diceNum = 0;
                }
                
         }
    
     }
       


}

