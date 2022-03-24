using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    if(health > 0)
    {
      if(Vector2.Distance(transform.position, target.position) > attackDistance)
      {
      transform.position = Vector2.MoveTowards(transform.position,target.position ,speed * Time.deltaTime);
      }
    }
    }
}
