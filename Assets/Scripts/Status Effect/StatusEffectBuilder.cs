using UnityEngine;

public class StatusEffectBuilder : MonoBehaviour
{
    public static StatusEffectBuilder Instance { get; private set; }

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

    //public static StatusEffect
}
