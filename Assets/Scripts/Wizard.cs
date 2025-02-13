using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int health = 100; 
    public int damage = 5;
    public float damageTimeScale = 1f;

    private float lastDamageTime;

    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            if (Time.time - lastDamageTime >= damageTimeScale){
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.TakeDamage(damage);
                    Debug.Log("Büyücü alanýnda ve enemy healthi: " + enemy.GetHealth());

                    
            TakeDamage(10);  


            Debug.Log("Büyücünün saðlýðý: " + health);

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
        Debug.Log("Büyücü öldü");
        Destroy(gameObject); 
   }
}
