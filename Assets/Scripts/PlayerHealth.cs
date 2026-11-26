using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ActorHealth
{
    [SerializeField] private ProgressBar healthBar;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetSize((float)currentHealth / (float)maxHealth);
    }

    public override void RestoreHealth(int amount)
    {
        base.RestoreHealth(amount);
        healthBar.SetSize((float)currentHealth / (float)maxHealth);
    }

    public override void Die()
    {
        currentHealth = 0;

        Destroy(this.gameObject, 0.5f);

        SceneManager.LoadScene(0);
    }

    public void AddMaxHealth(int amount)
    {
        maxHealth += amount;
        healthBar.SetSize((float)currentHealth / (float)maxHealth);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PlayerHealth : MonoBehaviour
//{
//    public float currentHealth;
//    public float maxHealth;
//    [SerializeField] private ProgressBar healthBar;


//    private void Start()
//    {
//        maxHealth = 300;
//        currentHealth = maxHealth;
//    }

//    private void Update()
//    {
//        if (currentHealth <= 0)
//        {
//            currentHealth = 0;

//            Destroy(this.gameObject, 0.5f);

//            this.GetComponent<BoxCollider2D>().enabled = false;

//            FindObjectOfType<GameManager>().ResetEnemyDamage();

//            SceneManager.LoadScene(0);
//        }

//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth;
//        }

//        healthBar.SetSize(currentHealth / maxHealth);
//    }

//    public void DoDamage(float damage)
//    {
//        currentHealth = currentHealth - damage;
//    }

//    public void AddHealth(float health)
//    {
//        currentHealth = currentHealth + health;
//    }
//}
