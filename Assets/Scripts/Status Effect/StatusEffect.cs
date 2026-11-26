using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public enum StatusEffectCode
    {
        Freeze = 0,
        Poison = 1
    }
    public delegate void EffectApplicator(Enemy enemy); // change this to a reference that has everything this class needs to change the status of.

    [field: SerializeField] public StatusEffectCode EffectCode { get; protected set; }

    [field: SerializeField] public float Duration = 0f;

    public EffectApplicator EntryEffect { get; protected set; }

    public EffectApplicator TickEffect { get; protected set; }
    [field: SerializeField] public float TickInterval { get; protected set; }
    [System.NonSerialized] public float NextTickTime = 0f; // https://discussions.unity.com/t/resetting-a-scriptable-object/718311/4

    public EffectApplicator ExitEffect { get; protected set; }
}
