using UnityEngine;

public class Archer : MonoBehaviour
{
    public int health = 100;

    private void Start()
    {
        Debug.Log("Okçu alanda  " + health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {

            TakeDamage(10);
        }
       
    }


    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            TakeDamage(8);
            Debug.Log("okçu saðlýk: " + health);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        //Debug.Log("yeni archer saðlýk : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("okçu öldü");
        Destroy(gameObject);
    }
}