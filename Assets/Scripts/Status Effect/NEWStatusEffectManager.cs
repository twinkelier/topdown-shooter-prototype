using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// based on https://www.reddit.com/r/gamedev/s/DAVWWmNbSm

[RequireComponent(typeof(Enemy))] // change this to something more generic eventually
public class NEWStatusEffectManager : MonoBehaviour
{
    [SerializeField] private List<StatusEffect> statusEffects;
    [SerializeField] private Enemy enemy; //CHANGE THIS TO SOMETBHING MORE GENERIC PLEASE

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void AddEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
        effect.EntryEffect.Invoke(enemy);
    }

    private void Update()
    {
        OnTickEffect();
        RemoveExpiredEffects();
    }

    public void OnTickEffect()
    {
        foreach (var effect in statusEffects)
        {
            if (effect.TickEffect != null) // would be stupid to do a tick with no tick effect
            {
                if (Time.timeSinceLevelLoad >= effect.NextTickTime)
                {
                    effect.TickEffect.Invoke(enemy);
                    effect.NextTickTime = Time.timeSinceLevelLoad + effect.TickInterval;
                }
            }
        }
    }

    public void RemoveExpiredEffects()
    {
        foreach (var effect in statusEffects.ToList())
        {
            if (effect.CanExpire == false) return;
            if (Time.timeSinceLevelLoad >= effect.CurrentTime)
            {
                statusEffects.Remove(effect);
                effect.ExitEffect?.Invoke(enemy);
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