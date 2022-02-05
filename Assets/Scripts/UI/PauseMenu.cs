using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
 
    public static bool GameISPaused = false;
  public GameObject pauseMenuUI;
  public GameObject player;
  public GameObject optionsMenu;
    // Update is called once per frame
    void Update()
    {
      if(optionsMenu.activeSelf == false)//проверка активности объекта Options, если не активен, то выполняется скрипт
      {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameISPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
      }
    }

    public void Resume()
    {
       pauseMenuUI.SetActive(false);
       player.SetActive(true);
       Time.timeScale = 1f;
       GameISPaused = false;
    }
    void Pause()
    {
       pauseMenuUI.SetActive(true);
       player.SetActive(false);
       Time.timeScale = 0f;
       GameISPaused = true;
    }
}
