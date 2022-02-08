using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public enum fireModeList
    {
      Single, 
      Auto, 
      Birst
    };
    public fireModeList fireMode;
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public bool isInRightHand;
    public float bulletSpeed;
    public float fireRate;
    public int ammo;
    public float reloadSpeed;
    public float gunDamage;
    public float gunAccuracy;
    public float mass;
    public AudioClip shot;
    public AudioClip reload;
    AudioSource audioSrs;

    
    private int allAmmo;
    private float ammoScatter;
    private float minAmmoScatter;
    private float maxAmmoScatter;
    private Quaternion nativeBulletRotation; //для хранения координат из начального положения пули

    // Update is called once per frame
    void Start()
    {
        audioSrs = GetComponent<AudioSource>();
        nativeBulletRotation = firePoint.rotation; //присваиваем начальное положени пули 
        maxAmmoScatter = Random.Range(0 , gunAccuracy/2);
        minAmmoScatter = Random.Range(0 , gunAccuracy/2);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Single)
        {
            Shot();
            audioSrs.PlayOneShot(shot);
        }
        if(Input.GetButton("Fire2") && fireMode == fireModeList.Auto)
        {
            if(!IsInvoking("Shot")) 
            {
               Invoke("Shot", fireRate); //Вызываем функцию Shot со скорость FireRate, в секундах
               audioSrs.PlayOneShot(shot);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        { //здесь задаете  любую кнопку
        audioSrs.PlayOneShot(reload);
        }

    }
    void Shot()
    {
        ammoScatter = Random.Range(0 , gunAccuracy/2);

        
        if(maxAmmoScatter >= minAmmoScatter)
        {  
            firePoint.transform.Rotate(new Vector3(0, 0, -ammoScatter));
            maxAmmoScatter -= ammoScatter;
        }
        else if(maxAmmoScatter <= minAmmoScatter)
        {
            firePoint.transform.Rotate(new Vector3(0, 0, +ammoScatter));
            minAmmoScatter -= ammoScatter;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
