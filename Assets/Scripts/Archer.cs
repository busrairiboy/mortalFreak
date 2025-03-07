using UnityEngine;

public class Archer : MonoBehaviour
{
    public int health = 100;

    private void Start()
    {
        Debug.Log("Ok�u alanda  " + health);
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
            Debug.Log("ok�u sa�l�k: " + health);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        //Debug.Log("yeni archer sa�l�k : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("ok�u �ld�");
        Destroy(gameObject);
    }
}