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
      if(PlayerPrefs.HasKey("score"))
      {
          PlayerPrefs.GetInt("score");
      }   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("score", score);
        hightScoreText.text = "HightScore:" + score;
    }
}
