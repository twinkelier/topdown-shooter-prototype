using UnityEngine;

[System.Serializable]
public class StatusEffect
{
    public enum StatusEffectCode
    {
        Freeze = 0,
        Poison = 1
    }
    public delegate void EffectApplicator(Enemy enemy); // change this to a reference that has everything this class needs to change the status of.

    public StatusEffectCode EffectCode;

    [SerializeField] private float duration = 0f;


    public EffectApplicator EntryEffect;

    public EffectApplicator TickEffect;
    public float TickInterval = 0f;
    public float NextTickTime = 0f;

    public EffectApplicator ExitEffect;

    public StatusEffect(StatusEffectCode code, float duration, EffectApplicator entryEffect,
                        EffectApplicator tickEffect, float tickInterval, float nextTickTime, 
                        EffectApplicator exitEffect)
    {
        EffectCode = code;
        this.duration = duration;
        EntryEffect = entryEffect;
        TickEffect = tickEffect;
        TickInterval = tickInterval;
        NextTickTime = nextTickTime;
        ExitEffect = exitEffect;
    }
}
