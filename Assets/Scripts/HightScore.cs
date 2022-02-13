using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{ 
    public int score;
    public Text hightScoreText;


    // Start is called before the first frame update
    void Start()
    {
      if(PlayerPrefs.HasKey("HightScore"))
      {
          PlayerPrefs.GetInt("HightScore");
      }   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("HightScore", score);
        hightScoreText.text = "HightScore: " + score;
    }
}
