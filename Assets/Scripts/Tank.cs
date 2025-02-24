using UnityEngine;

public class Tank : MonoBehaviour
{
    public int health = 200; 
    public int damage = 15; 
    public float damageInterval = 2f; //hasar aralýðý diðerlerinden fazla olmalý ,bence yani?
    public int armor = 20; 

    private float lastDamageTime;

    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy")){

            if (Time.time - lastDamageTime >= damageInterval){
                Enemy enemy = other.GetComponent<Enemy>();

                if (enemy != null) { 
                    int reducedDamage = Mathf.Max(0, damage - armor); //// hasarý armordan çýkararak uyguladým
                    enemy.TakeDamage(reducedDamage);

                    TakeDamage(5);
                    Debug.Log("Tank alanda ve enemy health: " + enemy.GetHealth());
                    Debug.Log("Tank'ýn saðlýðý: " + health);
                    lastDamageTime = Time.time;
   }
     }
        }
    }
    public void TakeDamage(int amount){
        health -= amount;
        if (health <= 0){
            Die();
}
    }
    private void Die(){
        Debug.Log("Tank öldü");
        Destroy(gameObject);
    }
}
