using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SfxManager sfxManager;

    public void HealthButton()
    {
        //playerHealth.maxHealth += 100;
        playerHealth.AddMaxHealth(100);

        gameManager.addDamageCalled = false;
        gameManager.amountOfUpgrades--;

        sfxManager.sfxInstance.AudioSource.PlayOneShot(sfxManager.sfxInstance.clickSound);

        if (gameManager.amountOfUpgrades == 0)
        {
            Invoke("StartEnemySpawners", 0);
            gameManager.startEnemySpawners = true;
            gameManager.shootingEnabled = true;
        }
    }

    public void AmmoButton()
    {
        playerController.maxAmmo += 10;

        gameManager.addDamageCalled = false;
        gameManager.amountOfUpgrades--;

        sfxManager.sfxInstance.AudioSource.PlayOneShot(sfxManager.sfxInstance.clickSound);

        if (gameManager.amountOfUpgrades == 0)
        {
            Invoke("StartEnemySpawners", 0);
            gameManager.startEnemySpawners = true;
            gameManager.shootingEnabled = true;
        }
    }

    public void DamageButton()
    {
        playerController.minDamage *= 1.15f;
        playerController.maxDamage *= 1.15f;

        gameManager.addDamageCalled = false;
        gameManager.amountOfUpgrades--;

        sfxManager.sfxInstance.AudioSource.PlayOneShot(sfxManager.sfxInstance.clickSound);

        if (gameManager.amountOfUpgrades == 0)
        {
            Invoke("StartEnemySpawners", 0);
            gameManager.startEnemySpawners = true;
            gameManager.shootingEnabled = true;
        }
    }

    public void StartEnemySpawners()
    {
        if (gameManager.startEnemySpawners)
        {
            for (int i = 0; i < gameManager.enemySpawners.Count; i++)
            {
                if (gameManager.enemySpawners[i] != null)
                {
                    gameManager.enemySpawners[i].StartEnemySpawner();
                }
            }

            gameManager.startEnemySpawners = false;
        }
    }
}
