using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public int HP = 25;
    public PlayerController playerHP;

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Player")
         {
               if(playerHP.playerHealth < 75)
               {
                playerHP.playerHealth +=HP;
                Destroy(gameObject);
               }
               if(playerHP.playerHealth >= 75 && playerHP.playerHealth < 100)
               {
                   playerHP.playerHealth += 100-playerHP.playerHealth;
                   Destroy(gameObject);
               }

         }
    }
}
