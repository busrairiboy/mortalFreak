using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float damageInterval = 1f; //aralýk

    private float lastDamageTime;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            if (Time.time - lastDamageTime >= damageInterval)
            {
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);

                    TakeDamage(5);

                    Debug.Log("Dövüþçü alanda ve enemy health: " + enemy.GetHealth());
                    Debug.Log("Dövüþçü saðlýðý: " + health);

                    lastDamageTime = Time.time;
                }
            }
        }
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log("Dövüþçü öldü");
        Destroy(gameObject);
    }
}
