using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActorHealth : MonoBehaviour, IHealth
{
    [SerializeField] protected int maxHealth = 300;
    [SerializeField] protected int currentHealth;
    public int CurrentHealth => currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public abstract void Die();
}
