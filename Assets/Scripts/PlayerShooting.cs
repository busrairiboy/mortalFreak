using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // Top prefab'ý
    public Transform firePoint; // Topun çýkýþ noktasý
    public float projectileSpeed = 5f; // Top hýzý
    public float projectileLifeTime = 3f; // Topun ne kadar süre sonra yok olacaðý
    public string enemyTag = "Enemy"; // Düþman tag'i

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Sol týk / Joystick butonu
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject targetEnemy = FindClosestEnemy(); // En yakýn düþmaný bul
        if (targetEnemy != null)
        {
            // Player ile Enemy arasýndaki yönü al
            Vector3 direction = targetEnemy.transform.position - transform.position;

            // FirePoint'ý oyuncu ile düþman arasýna konumlandýr
            firePoint.position = transform.position + direction.normalized;

            // Topu oluþtur
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Fýrlatma yönünü hesapla
            Vector2 shootDirection = direction.normalized;
            rb.velocity = shootDirection * projectileSpeed;

            // Belirlenen süre sonunda topu yok et
            Destroy(projectile, projectileLifeTime);
        }
    }

    // En yakýn düþmaný bulma fonksiyonu
    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    // Topun düþmana çarpma durumu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer top bir düþmana çarparsa, "Enemy" tag'ine sahip objelere hasar ver
        if (collision.gameObject.CompareTag(enemyTag))
        {
            // Enemy'e hasar ver
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10); // Hasar ver
            }

            // Topu yok et
            Destroy(gameObject); // Topu yok et
        }
    }
}
