using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    //Health
    [SerializeField] Slider healthslider;
    [SerializeField] PlayerStats playerHealth;

    //Score
    [SerializeField] TextMeshProUGUI scoreText;
    

    //Gold
    [SerializeField] TextMeshProUGUI currentGold;
    Bank bank;

    //Wave
    [SerializeField] TextMeshProUGUI waveText;

    //NaME
    [SerializeField] TextMeshProUGUI namer;
    [SerializeField] NameSet nameSet;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerStats>();
        bank = FindObjectOfType<Bank>();
        
        
    }

    void Start()
    {
        healthslider.maxValue = playerHealth.GetHealth();
        
    }

    
    void Update()
    {
        healthslider.value = playerHealth.GetHealth();
        
        namer.text = nameSet.Name().ToString();

        currentGold.text = bank.currentBalance.ToString();

        scoreText.text = playerHealth.GetScore().ToString();

    }
}
