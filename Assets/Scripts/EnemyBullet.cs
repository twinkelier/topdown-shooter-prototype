using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    public float bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnBulletHit();

            collision.GetComponent<IHealth>().TakeDamage((int)bulletDamage);
        }
    }

    private void OnBulletHit()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        Destroy(effect, 1f);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyBullet : MonoBehaviour
//{
//    [SerializeField] private GameObject hitEffect;
//    public float bulletDamage;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            OnBulletHit();

//            collision.GetComponent<PlayerHealth>().DoDamage(bulletDamage);
//        }
//    }

//    private void OnBulletHit()
//    {
//        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

//        Destroy(this.gameObject);
//        Destroy(effect, 1f);
//    }
//}
