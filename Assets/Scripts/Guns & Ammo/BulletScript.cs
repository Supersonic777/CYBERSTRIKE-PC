using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public GameObject hitEffect;//назначаем объект который выступит эффектом после попадания
   
   void OnCollisionEnter2D(Collision2D collision)
   {
      if(collision.gameObject.tag != "Bullet")
      {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);//местоположение возникновения эффекта
        Destroy(effect, 0.1f);//уничтожаем эффект после данного количества времени
        Destroy(gameObject);
      }
   }
   void Update()
   {
      Destroy(gameObject, 2.0f); //предполагается удаление объекта если он не попал в цель
   }
}
