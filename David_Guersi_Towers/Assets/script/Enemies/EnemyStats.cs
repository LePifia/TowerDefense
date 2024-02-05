using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    public int currentHealth;

    [Tooltip ("Adds more Health every time an enemy dies")]
    //[RequireComponent(typeof(Enemy))] con esto encima de tu código, obligas a que haya otro componente en el editor, puede reducir trabajo
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] ParticleSystem blood;


    [SerializeField] int goldReward = 25;
    [SerializeField] int scoreReward = 5;
    

    Bank bank;
    ScoreManager scoreManager;
    PlayerStats playerStats;
    AudioManager audioManager;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        bank = FindObjectOfType<Bank>();
        scoreManager = FindObjectOfType<ScoreManager>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(1);
    }
    
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        
        audioManager.CasualExplosion();

        if (currentHealth <= 0)
        {
            RewardGold();
            RewardScore();
            DefeatEffect();
            maxHealth += difficultyRamp;
            DIE();
        }
    }

    public void RewardGold()
    {
        if (bank == null) {return;}
        bank.Deposit(goldReward);
    }

    public void RewardScore()
    {
        playerStats.totalScore += scoreReward;
    }

    void DefeatEffect()
    {
        if (blood != null)
        {
            ParticleSystem Instance = Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(Instance.gameObject, Instance.main.duration + Instance.main.startLifetime.constantMax);
        }
    }

    void DIE()
    {
        audioManager.PlayerExplosion();
        DefeatEffect();
        gameObject.SetActive(false);
        
    }

}