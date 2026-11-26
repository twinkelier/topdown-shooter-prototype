using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IHealth>().RestoreHealth(Random.Range(50, 76));

            Destroy(this.gameObject, 0.1f);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealthDrop : MonoBehaviour
//{
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            collision.GetComponent<PlayerHealth>().AddHealth(Random.Range(50, 76));

//            Destroy(this.gameObject, 0.1f);
//        }
//    }
//}
