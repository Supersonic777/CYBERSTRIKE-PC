using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float armor;
    public float health;
    public int damage = 5;
    public float attackDistance;
    public GameObject atackTarget;
    private string[] typeList = new string[]{"Bomber", "Defender", "Spider","Scout","Engineer"};
    private Transform target;
    //private PlayerController giveDamage = new PlayerController();
    void Start()
    {;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        if(Vector2.Distance(transform.position, target.position) > attackDistance)
        {
        transform.position = Vector2.MoveTowards(transform.position,target.position ,speed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Bullet")
      {
       //health -= FindObjectOfType<GunController>().gunDamage;
        if(health <=0)
        {
            Destroy(gameObject);
        }
      }
      if(collision.gameObject.tag == "Player")
      {
        //giveDamage.playerHealth -= damage;
        FindObjectOfType<PlayerController>().playerHealth -= damage;
      }
    }
}

