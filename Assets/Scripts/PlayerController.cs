using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private Camera cam = null;
    private Vector2 inputVelocity;
    private Vector2 mousePos;
    private Rigidbody2D rb;

    [Header("Gun")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunSmokePrefab;
    [SerializeField] private float timeBetweenShots = 0;
    [SerializeField] private float bulletSpeed;
    public float minDamage;
    public float maxDamage;
    public float currentAmmo;
    public float gunDamage;
    public float maxAmmo;

    [Header("Ammo")]
    [SerializeField] private ProgressBar bulletBar;

    private GameManager gameManager;

    private float shootingTimeStamp = 0;
    private float reloadTime = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = FindObjectOfType<GameManager>();

        currentAmmo = maxAmmo;

        minDamage = 50;
        maxDamage = 75;
    }

    void Update()
    {
        print(gameManager.shootingEnabled);
        gunDamage = Random.Range(minDamage, maxDamage);

        Movement();
        bulletBar.SetSize(currentAmmo / maxAmmo);

        if (Input.GetMouseButton(0) && currentAmmo > 0 && Time.time >= shootingTimeStamp && gameManager.shootingEnabled == true)
        {
            Shooting();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.shootingEnabled = false;
            StartCoroutine(Reloading());
        }
    }

    private void Movement()
    {
        inputVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = inputVelocity * moveSpeed;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    private void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject gunSmoke = Instantiate(gunSmokePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = firePoint.up * bulletSpeed;

        Destroy(bullet, 3f);
        Destroy(gunSmoke, 1f);

        currentAmmo--;

        shootingTimeStamp = Time.time + timeBetweenShots;
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        gameManager.shootingEnabled = true;
    }
}
