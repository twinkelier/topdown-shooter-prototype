using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private List<StatusEffect> onHitStatusEffects;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnBulletHit();

            collision.GetComponent<IHealth>().TakeDamage((int)playerController.gunDamage);

            foreach (var effect in onHitStatusEffects)
            {
                collision.GetComponent<NEWStatusEffectManager>().AddEffect(effect);
            }
        }
    }

    private void OnBulletHit()
    {   
        GameObject effect = Instantiate(hitParticle, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        Destroy(effect, 1f);
    }
}
