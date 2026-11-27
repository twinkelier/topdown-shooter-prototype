using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Poison Status Effect")]
public class PoisonStatusEffect : StatusEffect
{
    [SerializeField] private int damageOverTime;

    protected override void OnEnable()
    {
        //EntryEffect += (Enemy e) =>
        //{
        //    if (e)
        //    {
        //        // here i could spawn in some kind of cool green on hit effect too
        //    }
        //};
        TickEffect += DoPoisonDamage;
    }

    private void DoPoisonDamage(Enemy enemy)
    {
        IHealth _health = enemy.gameObject.GetComponent<IHealth>();
        _health.TakeDamage(damageOverTime);
        Debug.Log($"<color=green>{damageOverTime} POISON DAMAGE</color>");
    }
}
