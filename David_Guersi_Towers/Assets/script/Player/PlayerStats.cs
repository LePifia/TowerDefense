using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int health = 5;
    
    MainMenu mainMenu;
    ScoreManager scoreManager;

    public int totalScore;


    private void Awake()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        scoreManager = FindObjectOfType<ScoreManager>();
        
    }

    private void Update()
    {
        PlayerPrefs.SetInt("scoreMax", totalScore);
        if (health <= 0)
        {
            DIE();
        }
    }

    
    public void DamageBase (int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            scoreManager.AddScore(new Score(PlayerPrefs.GetString("NameRank"), PlayerPrefs.GetInt("scoreMax")));
            DIE();
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

    void DIE()
    {
        gameObject.SetActive(false);

        mainMenu.HighScoresLoader();
    }

    public int GetHealth()
    {
        return health;
    }
}
