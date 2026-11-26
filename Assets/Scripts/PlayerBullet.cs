using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
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
        }
    }

    private void OnBulletHit()
    {   
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        Destroy(effect, 1f);
    }
}
