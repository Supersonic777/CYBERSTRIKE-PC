using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoEnumerator : MonoBehaviour
{
    public int fullAmmo;
    public int ammo;
    public Text ammoEnumeratorText;


    // Start is called before the first frame update
    void Start()
    {
    
    ammo = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>().ammoInMag;
    if(PlayerPrefs.HasKey("Ammo"))
    {
      PlayerPrefs.GetInt("Ammo");
    }   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Ammo", ammo);
        ammoEnumeratorText.text = "Ammo: " + ammo + " | " + fullAmmo;
    }
}
