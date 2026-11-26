using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timeToSpawn;
    private GameManager gameManager;

    void Start()
    {
        StartEnemySpawner();
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.AddEnemySpawner(this);
        }
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2();

        int randomInt = Random.Range(0, 4);

        switch (randomInt)
        {
            case 0:
                spawnPosition = new Vector2(-9.5f, Random.Range(-5.5f, 5.5f));
                break;
            case 1:
                spawnPosition = new Vector2(9.5f, Random.Range(-5.5f, 5.5f));
                break;
            case 2:
                spawnPosition = new Vector2(Random.Range(-9.5f, 9.5f), -5.5f);
                break;
            case 3:
                spawnPosition = new Vector2(Random.Range(-9.5f, 9.5f), 5.5f);
                break;
        }

        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

    public void StopEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
    }

    public void StartEnemySpawner()
    {
        InvokeRepeating("SpawnEnemy", timeToSpawn, timeToSpawn);
    }
}
