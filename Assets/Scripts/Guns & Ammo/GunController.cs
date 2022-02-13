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
    public GameObject reloadNotification;
    //public bool isInRightHand;
    public float bulletSpeed;
    public float fireRate;
    public int allAmmo;
    public int ammoInMag;
    public int shootgunFraction;
    public float reloadSpeed;
    public float gunDamage;
    public float gunAccuracy;
    public float mass;
    public AudioClip shot;
    public AudioClip reloadSound;
    AudioSource audioSrs;


    private int ammoInMagNow;
    private float ammoScatter;
    private float minAmmoScatter;
    private float maxAmmoScatter;
    private Quaternion nativeBulletRotation; //для хранения координат из начального положения пули

    // Update is called once per frame
    void Start()
    {
        ammoInMagNow = ammoInMag;
        audioSrs = GetComponent<AudioSource>();
        nativeBulletRotation = firePoint.rotation; //присваиваем начальное положени пули 
        maxAmmoScatter = Random.Range(0 , gunAccuracy/2);
        minAmmoScatter = Random.Range(0 , gunAccuracy/2);
    }
    void Update()
    {
      if(ammoInMagNow > 0)
      {
      //блок управления стрельбой обыкновенного пистолета
      if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Single)
      {
        Shot();
        audioSrs.PlayOneShot(shot);
        ammoInMagNow--;
        gameObject.GetComponent<AmmoEnumerator>().ammo --;
      }
        //блок управления стрельбой пистолета-пулемёта
      if(Input.GetButton("Fire1") && fireMode == fireModeList.Auto)
      {
        if(!IsInvoking("Shot")) 
        {
            Invoke("Shot", fireRate); //Вызываем функцию Shot со скорость FireRate, в секундах
            audioSrs.PlayOneShot(shot);
            ammoInMagNow--;
            gameObject.GetComponent<AmmoEnumerator>().ammo --;
        }
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
      }
      }
      //блок управления перезарядкой
      if (ammoInMagNow != ammoInMag && Input.GetKeyDown(KeyCode.R))
      { //здесь задаете  любую кнопку
        reloadNotification.SetActive(true);
        audioSrs.PlayOneShot(reloadSound);
        Invoke("Shot", reloadSpeed);
        Invoke("Reload", reloadSpeed);
        ammoInMagNow = ammoInMag;
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
      if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
      {
      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
      }
    }
    void Reload()
    {
      reloadNotification.SetActive(false);
      gameObject.GetComponent<AmmoEnumerator>().ammo = ammoInMag;
    }
}
