using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    static bool GameIsPaused = false;
    

    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape)) {
         
         if(GameIsPaused) {
             Resume();
         }
         else{
             Pause();
         }

     }
    }
     

    public void Resume() {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;

    }

    void Pause() {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit() {
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}
