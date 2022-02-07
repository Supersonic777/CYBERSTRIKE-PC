using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
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
    public float bulletSpeed;
    public float fireRate;
    public int ammo;
    public float reloadSpeed;
    public int gunDamage;
    public int damage;
    public float accuracy;
    public float mass;
    public AudioClip shot;
    public AudioClip reload;
    AudioSource audioSrs;

    

    private int allAmmo;

    // Update is called once per frame
    void Start()
    {
         audioSrs = GetComponent<AudioSource>();
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
