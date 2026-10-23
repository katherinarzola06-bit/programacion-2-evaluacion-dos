using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 12f;
    [Header("Cadencia de Disparo")]
    [SerializeField] private float timeBetweenShots = 0.5f; // Tiempo de espera entre disparos
    private float nextShotTime = 0f; // Control del temporizador
    void Update()
    {
        // Verificamos si se presiona el botón y si ya pasó el tiempo necesario
        if (Input.GetButtonDown("Fire1") && Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + timeBetweenShots; // Actualizamos el próximo momento permitido
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        float dir = transform.localScale.x >= 0 ? 1f : -1f;
        rb.linearVelocity = new Vector2(dir * bulletSpeed, 0f);
    }
}