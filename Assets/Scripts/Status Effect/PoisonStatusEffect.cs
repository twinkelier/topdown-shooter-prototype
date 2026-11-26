using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Poison Status Effect")]
public class PoisonStatusEffect : StatusEffect
{
    [SerializeField] private int damageOverTime;

    private void OnValidate()
    {
        EntryEffect += (Enemy e) =>
        {
            if (e)
            {
                Debug.Log("ON HIT EFFECT BABY");
                // here i could spawn in some kind of cool green on hit effect too
            }
        };
        TickEffect += DoPoisonDamage;
    }

    private void DoPoisonDamage(Enemy enemy)
    {
        IHealth _health = enemy.gameObject.GetComponent<IHealth>();
        _health.TakeDamage(damageOverTime);
    }
}
