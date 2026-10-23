using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int shotsPerBurst = 3;
    [SerializeField] private float timeBetweenShots = 0.25f;
    [SerializeField] private float timeBetweenBursts = 2f;

    [Header("Player Detection")]
    [SerializeField] private float attackRange = 5f;

    [Header("Shooting Sound")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip shootSound;

    private Transform player;
    private float timer;
    private int shotsFired;
    private bool isBursting;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        timer = timeBetweenBursts;
    }

    private void Update()
    {
        if (player == null || projectilePrefab == null || shootingPoint == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            timer += Time.deltaTime;

            if (isBursting)
            {
                if (timer >= timeBetweenShots)
                {
                    Shoot();
                    shotsFired++;
                    timer = 0f;

                    if (shotsFired >= shotsPerBurst)
                    {
                        isBursting = false;
                    }
                }
            }
            else if (timer >= timeBetweenBursts)
            {
                isBursting = true;
                shotsFired = 0;
                timer = timeBetweenShots;
            }
        }
        else
        {
            timer = 0f;
            shotsFired = 0;
            isBursting = false;
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            shootingPoint.position,
            Quaternion.identity
        );

        Vector2 direction = (player.position - shootingPoint.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }

        if (sfxSource != null && shootSound != null)
        {
            sfxSource.PlayOneShot(shootSound);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
