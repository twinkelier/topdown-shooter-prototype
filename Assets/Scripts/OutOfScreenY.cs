using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenY : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y * -1);
        }
    }
}
