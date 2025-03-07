using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int health = 100;

    private void Start()
    {
        Debug.Log("Dövüþçü alanda  " + health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {

            TakeDamage(9);
        }

    }


    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            TakeDamage(8);
             Debug.Log("dövüþçü saðlýk: " + health);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
       // Debug.Log("yeni dövüþçü saðlýk : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("dövüþçü öldü");
        Destroy(gameObject);
    }
}