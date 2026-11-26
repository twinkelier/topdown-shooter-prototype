using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffects
{
    Freeze,
    Poison
}

public class StatusEffectManager : MonoBehaviour
{
    private Dictionary<Enemy, HashSet<StatusEffects>> enemiesWithSE = new Dictionary<Enemy, HashSet<StatusEffects>>();

    public static StatusEffectManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        foreach (var (key, value) in enemiesWithSE) //https://www.reddit.com/r/csharp/comments/1c984zk/c_how_to_iterate_over_a_dictionary/
        {
            foreach (var statusEffect in value)
            {
                switch (statusEffect)
                {
                    case StatusEffects.Freeze:
                        break;
                    case StatusEffects.Poison:
                        break;
                }
            }
        }
    }

    public void Register(StatusEffects statusEffect, Enemy enemy)
    {
        //enemiesWithSE.Add(statusEffect, enemy);
        if (!enemiesWithSE.ContainsKey(enemy))
        {
            var se = new HashSet<StatusEffects> { statusEffect };
            enemiesWithSE.Add(enemy, se);
        }
        else enemiesWithSE[enemy].Add(statusEffect);
        print("status effect: " + statusEffect + " given to: " + enemy.name);
    }

    public void UnRegister(StatusEffects statusEffect, Enemy enemy)
    {
        //enemiesWithSE.Remove(statusEffect);
        enemiesWithSE[enemy].Remove(statusEffect);
        print("status effect: " + statusEffect + " removed from: " + enemy.name);
    }
}
