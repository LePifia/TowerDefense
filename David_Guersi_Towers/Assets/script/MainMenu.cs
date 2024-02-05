using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void HighScoresLoader()
    {
        
                SceneManager.LoadScene("HighScores");
         
    }
}
