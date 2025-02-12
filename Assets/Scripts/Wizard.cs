using UnityEngine;

public class Wizard : MonoBehaviour
{
    //wizard hasar almalý
    public int damage = 5; 
    public float damageTimeScale = 1f; 

    private float lastDamageTime; 

    private void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.CompareTag("Enemy"))
        {
           
            if (Time.time - lastDamageTime >= damageTimeScale)
            {
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage); 
                    Debug.Log(" büyücü alanýnda ve enemy healthi: " + enemy.GetHealth()); 

                    lastDamageTime = Time.time; 
                }
            }
        }
    }
}
