using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour 
{

    public float playerHealth = 100;
	public float speed = 2f;
	public float acceleration = 6f;
	public float staminaFill = 1f;
	public GameObject dieMessage;
	public Rigidbody2D rb;
	public Camera cam;
	public Image bar;
	public Image stamina;
	public AudioClip walkSound;
	public AudioClip runSound;
	private float healthFill;
	Vector2 movement;
	Vector2 mousePos;
	AudioSource playerAudioSrs;
	void Start()
	{
        playerAudioSrs = GetComponent<AudioSource>();
	}

	void Update () 
	{
		healthFill = playerHealth/100f;
        bar.fillAmount = healthFill;
		stamina.fillAmount = staminaFill;

		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		if(playerHealth<=0)
		{
			dieMessage.SetActive(true);
			gameObject.SetActive(false); //деактивирует игрока при обнулении HP
		}
	}
	void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A))
		{
		   if(Input.GetKey(KeyCode.LeftShift))
		   {
			   if(staminaFill >0)
			   {
			    	rb.MovePosition(rb.position +  movement * acceleration * Time.fixedDeltaTime);
			        staminaFill -= 0.002f;
			   }
			   else
			   {
			    	rb.MovePosition(rb.position +  movement * speed * Time.fixedDeltaTime);
			        //staminaFill +=0.001f;
			   }
		   }
	
		   else
		   {
			   if(staminaFill<1)
			   {
		         staminaFill +=0.001f;
		       }
		   rb.MovePosition(rb.position +  movement * speed * Time.fixedDeltaTime);
		   }
		}
		
		else if(staminaFill < 1)
		{
		   staminaFill +=0.004f;
		}
		   Vector2 lookDir = mousePos - rb.position;
		   float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;  //+-90 градусов
		   rb.rotation = angle;
	}

}	


	/*void OnCollisionEnter2D(Collision2D enemy)
{
    if (enemy.gameObject.tag == "Enemy")
        StartCoroutine(ToDamage());
}

/*void OnCollisionExit2D(Collision2D enemy)
{
    if (enemy.gameObject.tag == "Enemy")
        StopAllCoroutines();
}

private IEnumerator ToDamage()
{
    //Отнимаем 1ед здоровья пока здоровье есть или пока корутина не будет остановлена
    while ( health > 0)
    {
        health -= 5;
        yield return new WaitForSeconds(0.4f);
    }
}*/

