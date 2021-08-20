using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        

    }

    public void PlayerVsPlayer(){
        Ball.player1Score = 0;
        Ball.player2Score = 0;
        SceneManager.LoadScene("Level01");
        
    }
    public void PlayerVsAI(){
        SceneManager.LoadScene("Level01AI");
        Ball.player1Score = 0;
        Ball.player2Score = 0;
    }
    public void Quit(){
        Application.Quit();
    }

}
