using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] [Range(1,50)] int poolSize = 15;

    [SerializeField] [Range(0.1f, 30)] float spawnEnemy = 1f;

    GameObject [] pool;

    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int index = 0; index < pool.Length; index++)
        {
            pool[index] = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform);
            pool[index].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    public IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnEnemy);
        }
    }
}
