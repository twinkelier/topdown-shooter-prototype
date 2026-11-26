using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// based on https://www.reddit.com/r/gamedev/s/DAVWWmNbSm

[RequireComponent(typeof(Enemy))] // change this to something more generic eventually
public class NEWStatusEffectManager : MonoBehaviour
{
    [SerializeField] private List<StatusEffect> statusEffects;
    private Enemy enemy; //CHANGE THIS TO SOMETBHING MORE GENERIC PLEASE

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void AddEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
        effect.EntryEffect?.Invoke(enemy);
    }

    private void Update()
    {
        OnTickEffect();
    }

    public void OnTickEffect()
    {
        foreach (var effect in statusEffects)
        {
            if (effect.NextTickTime > effect.TickInterval)
            {
                effect.TickEffect?.Invoke(enemy);
                effect.NextTickTime = effect.TickInterval + Time.timeSinceLevelLoad;
            }
        }
    }

    public void RemoveEffect(StatusEffect.StatusEffectCode code)
    {
        foreach (var effect in statusEffects.ToList())
        {
            if (effect.EffectCode.Equals(code))
            {
                statusEffects.Remove(effect);
                effect.ExitEffect?.Invoke(enemy);
                return;
            }
        }
    }
}