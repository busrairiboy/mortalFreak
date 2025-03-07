using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int health = 100;
    public int damage = 5;
    public float damageTimeScale = 5f;
    public float noDamageRadius = 2f; 

    private float lastDamageTime;

    // private bool isPlayerInArea = false;  // Player'ýn alanda olup olmadýðýný kontrol ederiz.




    private void Start()
    {
        Debug.Log("Büyücü alanda  " + health);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       
        if (other.collider.CompareTag("Player"))
        {
            TakeDamage(8); 
            Debug.Log("Wizard saðlýk: " + health);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            TakeDamage(8); 
           // Debug.Log("Wizard saðlýk: " + health);
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
        Debug.Log("Wizard öldü");
        Destroy(gameObject); 
    }
}
