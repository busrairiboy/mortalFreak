using UnityEngine;

public class Archer : MonoBehaviour
{
    // büyücü hasar almalý 
    //wizard ve healer konumu iç içe geçiyorlar.

    public int damage = 10;
    public float damageInterval = 1f;

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


                    Debug.Log("okçu alaanda enemy healthi:  " + enemy.GetHealth());

                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
