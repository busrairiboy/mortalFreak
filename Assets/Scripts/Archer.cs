using UnityEngine;

public class Archer : MonoBehaviour
{
    // b�y�c� hasar almal� 
    //wizard ve healer konumu i� i�e ge�iyorlar.

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


                    Debug.Log("ok�u alaanda enemy healthi:  " + enemy.GetHealth());

                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
