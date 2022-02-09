using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public enum fireModeList
    {
      Single, 
      Auto, 
      Birst,
      Shootgun
    };
    public fireModeList fireMode;
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public bool isInRightHand;
    public float bulletSpeed;
    public float fireRate;
    public int ammo;
    public int shootgunFraction;
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
        //блок управления стрельбой обыкновенного пистолета
        if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Single)
        {
            Shot();
            audioSrs.PlayOneShot(shot);
        }
        //блок управления стрельбой пистолета-пулемёта
        if(Input.GetButton("Fire1") && fireMode == fireModeList.Auto)
        {
            if(!IsInvoking("Shot")) 
            {
               Invoke("Shot", fireRate); //Вызываем функцию Shot со скорость FireRate, в секундах
               audioSrs.PlayOneShot(shot);
            }
        }
        //блок управления перезарядкой
        if (Input.GetKeyDown(KeyCode.R))
        { //здесь задаете  любую кнопку
        audioSrs.PlayOneShot(reload);
        }
        //блок управления дробовиком
        if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Shootgun)
        {
           while(shootgunFraction > 0)
           {
               Shot();
               shootgunFraction --;
           }

            audioSrs.PlayOneShot(shot);
            //if(!IsInvoking("Shot")) 
           // {
            //   Invoke("Shot", fireRate); //Вызываем функцию Shot со скорость FireRate, в секундах
            //   audioSrs.PlayOneShot(shot);
           // }
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
