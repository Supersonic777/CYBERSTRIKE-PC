using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    public float giveStamina = 0.25f;
    public PlayerController PlayerStamina;

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Player")
         {
               if(PlayerStamina.staminaFill < 0.75f)
               {
                PlayerStamina.staminaFill +=giveStamina;
                Destroy(gameObject);
               }
               if(PlayerStamina.staminaFill >= 0.75f && PlayerStamina.staminaFill < 1.0f)
               {
                   PlayerStamina.staminaFill += 1.0f-PlayerStamina.staminaFill;
                   Destroy(gameObject);
               }

         }
    }
}
