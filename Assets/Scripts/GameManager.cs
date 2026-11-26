using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool addDamageCalled = true;

    public bool shootingEnabled = true;

    [Header("Experience")]
    [SerializeField] private ProgressBar expBarScript;
    [SerializeField] private GameObject levelButtons;
    public float currentLevel = 1;
    private float nextLevel = 1f;
    public float expAdd;
    public float currentExp;
    private float minimumExp;
    private float maximumExp;
    public float amountOfUpgrades = 0;

    [Header("Enemy")]
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] public List<EnemySpawner> enemySpawners;
    [SerializeField] private Enemy enemy;
    public bool startEnemySpawners = false;

    [Header("Pausing the game")]
    public bool slowedDown = false;
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject blur;

    private void Start()
    {
        minimumExp = 0.1f;
        maximumExp = 0.6f;
        ResetEnemyDamage();
    }

    private void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        //print(Time.timeScale);
        XpAdder();

        if (Enemies.Count <= 0 && amountOfUpgrades > 0)
        {
            levelButtons.SetActive(true);
            shootingEnabled = false;
            if (!addDamageCalled)
            {
                Invoke("AddEnemyDamage", 0);
            }
        }
        else
        {
            levelButtons.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!slowedDown)
            {
                Time.timeScale = 0;
                pauseButtons.SetActive(true);
                blur.SetActive(true);
                shootingEnabled = false;
            }
            else if (slowedDown)
            {
                Time.timeScale = 1;
                pauseButtons.SetActive(false);
                blur.SetActive(false);
                shootingEnabled = false;
            }

            slowedDown = !slowedDown;
        }
    }

    private void XpAdder()
    {
        
        expAdd = Random.Range(minimumExp, maximumExp);

        if (currentExp >= nextLevel)
        {
            minimumExp /= 1.2f;
            maximumExp /= 1.2f;

            currentExp = 0;

            currentLevel++;

            LevelUp();

            amountOfUpgrades++;
        }

        expBarScript.SetSize(currentExp);
    }

    private void LevelUp()
    {
        for (int i = 0; i < enemySpawners.Count; i++)
        {
            if (enemySpawners[i] != null)
            {
                enemySpawners[i].StopEnemySpawner();
            }
        }
    }

    public void AddEnemyDamage()
    {
        enemy.minDamage *= 1.1f;
        enemy.maxDamage *= 1.1f;
        addDamageCalled = true;
    }

    public void ResetEnemyDamage()
    {
        enemy.minDamage = 50;
        enemy.maxDamage = 75;
    }

    public void AddEnemy(GameObject go)
    {
        Enemies.Add(go);
    }

    public void RemoveEnemy(GameObject go)
    {
        Enemies.Remove(go);
    }

    public void AddEnemySpawner(EnemySpawner go)
    {
        enemySpawners.Add(go);
    }
}
