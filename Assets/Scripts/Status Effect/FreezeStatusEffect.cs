using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Freeze Status Effect")]
public class FreezeStatusEffect : StatusEffect
{
    [System.NonSerialized] private float storedSpeed;
    protected override void OnEnable()
    {
        EntryEffect += Freeze; // freeze enemy
        EntryEffect += (Enemy e) =>
        {
            CurrentTime = Time.timeSinceLevelLoad + Duration;
            Debug.Log(CurrentTime);
        };
        ExitEffect += UnFreeze; // unfreeze enemy
    }

    private void Freeze(Enemy enemy)
    {
        storedSpeed = enemy.MoveSpeed;
        enemy.MoveSpeed = 0;
    }

    private void UnFreeze(Enemy enemy)
    {
        enemy.MoveSpeed = storedSpeed;
    }
}
