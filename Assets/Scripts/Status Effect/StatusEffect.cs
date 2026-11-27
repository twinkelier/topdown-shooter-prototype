using System;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public enum StatusEffectCode
    {
        FREEZE = 0,
        POISON = 1,
        HEALING = 2,
        STUN = 3,
        BLEED = 4,
    }
    public delegate void EffectApplicator(Enemy enemy); // change this to a reference that has everything this class needs to change the status of.

    protected abstract void OnEnable();

    [field: SerializeField] public StatusEffectCode EffectCode { get; protected set; }

    [field: SerializeField] public bool CanExpire { get; protected set; }
    [field: SerializeField] public float Duration { get; protected set; }
    [System.NonSerialized] public float CurrentTime = 0f;

    public EffectApplicator EntryEffect { get; protected set; }

    public EffectApplicator TickEffect { get; protected set; }
    [field: SerializeField] public float TickInterval { get; protected set; }
    [System.NonSerialized] public float NextTickTime = 0f; // https://discussions.unity.com/t/resetting-a-scriptable-object/718311/4

    public EffectApplicator ExitEffect { get; protected set; }
}
