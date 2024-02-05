using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    Bank bank;
    [SerializeField] int cost = 75;
    
   public bool CreateTower(TowerStats tower, Vector3 position)
    {
        bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.currentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.WithDraw(cost);
            return true;
        }

        return false;
    }
}
