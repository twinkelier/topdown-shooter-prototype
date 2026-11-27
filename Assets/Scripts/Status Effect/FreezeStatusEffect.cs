using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Freeze Status Effect")]
public class FreezeStatusEffect : StatusEffect
{
    [System.NonSerialized] private float storedSpeed;
    protected override void OnEnable()
    {
        EntryEffect += Freeze; // freeze enemy
        ExitEffect += UnFreeze; // unfreeze enemy
    }

    protected override void OnDisable()
    {
        //EntryEffect -= Freeze;
        //ExitEffect -= UnFreeze;
    }

    private void Freeze(Enemy enemy)
    {
        storedSpeed = enemy.MoveSpeed;
        enemy.MoveSpeed = 0;
        CurrentTime = Time.timeSinceLevelLoad + Duration;
        Debug.Log($"time: {Time.timeSinceLevelLoad}, current time: {CurrentTime}");
    }

    private void UnFreeze(Enemy enemy)
    {
        enemy.MoveSpeed = storedSpeed;
    }
}
