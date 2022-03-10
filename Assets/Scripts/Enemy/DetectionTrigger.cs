using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
    public GameObject korpus;
    public GameObject bashnya;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            korpus.GetComponent<Rotator>().enabled = true;
            bashnya.GetComponent<Rotator>().enabled = true;
        }
        else
        {
            korpus.GetComponent<Rotator>().enabled = false;
            bashnya.GetComponent<Rotator>().enabled = false;
        }
    }
}
