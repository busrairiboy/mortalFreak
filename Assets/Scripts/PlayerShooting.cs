using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // Top prefab'�
    public Transform firePoint; // Topun ��k�� noktas�
    public float projectileSpeed = 5f; // Top h�z�
    public float projectileLifeTime = 3f; // Topun ne kadar s�re sonra yok olaca��
    public string enemyTag = "Enemy"; // D��man tag'i

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Sol t�k / Joystick butonu
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject targetEnemy = FindClosestEnemy(); // En yak�n d��man� bul
        if (targetEnemy != null)
        {
            // Player ile Enemy aras�ndaki y�n� al
            Vector3 direction = targetEnemy.transform.position - transform.position;

            // FirePoint'� oyuncu ile d��man aras�na konumland�r
            firePoint.position = transform.position + direction.normalized;

            // Topu olu�tur
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // F�rlatma y�n�n� hesapla
            Vector2 shootDirection = direction.normalized;
            rb.velocity = shootDirection * projectileSpeed;

            // Belirlenen s�re sonunda topu yok et
            Destroy(projectile, projectileLifeTime);
        }
    }

    // En yak�n d��man� bulma fonksiyonu
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

    // Topun d��mana �arpma durumu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er top bir d��mana �arparsa, "Enemy" tag'ine sahip objelere hasar ver
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
