using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBetweenShots = 0;
    /*[HideInInspector]*/ public float minDamage;
    /*[HideInInspector]*/ public float maxDamage;
    private EnemyBullet enemyBullet;
    private float timeStamp = 0;

    [Header("Movement")]
    public float MoveSpeed;
    private Transform player;

    [Header("Remove and Add Enemies")]
    private GameManager gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        gameManager = FindObjectOfType<GameManager>();

        enemyBullet = bulletPrefab.GetComponent<EnemyBullet>();

        minDamage = 50;
        maxDamage = 75;


        if (gameManager != null)
        {
            gameManager.AddEnemy(this.gameObject);
        }
    }

    void Update()
    {

        enemyBullet.bulletDamage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage));

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Vector2.Distance(transform.position, player.position) >= 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) <= 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -(MoveSpeed + 6) * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) < 4)
        {
            if (Time.time >= timeStamp)
            {
                Shooting();
            }
        }
    }

    private void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = firePoint.up * bulletSpeed;

        Destroy(bullet, 3f);

        timeStamp = Time.time + timeBetweenShots;
    }
}
