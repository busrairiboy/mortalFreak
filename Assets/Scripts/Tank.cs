using UnityEngine;

public class Tank : MonoBehaviour
{
    public int health = 200;

    private void Start()
    {
        Debug.Log("Tank alanda  " + health);
    }




    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            TakeDamage(10);
            Debug.Log("tank sa�l�k: " + health);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player")) 
        {
           
            TakeDamage(10); 
        }
        /* else
        {
            Debug.Log("tank�n alan�nda �unlar da varr " + collision.gameObject.name);
        }*/
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
       // Debug.Log("yeni sa�l�k : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Tank �ld�");
        Destroy(gameObject); 
    }
}
