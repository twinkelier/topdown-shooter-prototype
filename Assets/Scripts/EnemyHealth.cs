using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : ActorHealth
{
    [SerializeField] private GameObject healthDrop;
    private GameManager gameManager;
    private bool expAddEnabled = true;

    protected override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && expAddEnabled == true)
        {
            Die();
        }
    }

    public override void Die()
    {
        currentHealth = 0;

        gameManager.RemoveEnemy(this.gameObject);

        gameManager.currentExp = (gameManager.currentExp + gameManager.expAdd);

        expAddEnabled = false;

        InstantiateHealthDrop();

        Destroy(this.gameObject, 0.1f);
    }

    private void InstantiateHealthDrop()
    {
        if (Random.Range(0, 5) == 2)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyHealth : MonoBehaviour
//{
//    [SerializeField] private float maxHealth;
//    [SerializeField] private float currentHealth;
//    [SerializeField] private GameObject healthDrop;
//    private GameManager gameManager;
//    private bool expAddEnabled = true;
//    private int randomInt = 0;

//    private void Start()
//    {
//        currentHealth = maxHealth;
//        gameManager = FindObjectOfType<GameManager>();
//    }

//    private void Update()
//    {
//        randomInt = Random.Range(0, 5);

//        if (currentHealth <= 0 && expAddEnabled == true)
//        {
//            currentHealth = 0;

//            gameManager.RemoveEnemy(this.gameObject);

//            gameManager.currentExp = (gameManager.currentExp + gameManager.expAdd);

//            expAddEnabled = false;

//            this.GetComponent<PolygonCollider2D>().enabled = false;

//            InstantiateHealthDrop();

//            Destroy(this.gameObject, 0.1f);
//        }

//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth;
//        }
//    }

//    private void InstantiateHealthDrop()
//    {
//        if (randomInt == 2)
//        {
//            Instantiate(healthDrop, transform.position, Quaternion.identity);
//        }
//    }

//    public void DoDamage(float damage)
//    {
//        currentHealth = currentHealth - damage;
//    }
//}
