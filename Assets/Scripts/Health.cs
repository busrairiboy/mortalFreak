using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

    private float health;

    public float _health { get => health; set => health = value; }
    public float getCurrentHealth()
    {
        return health;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Karakter öldü..");
            Die();
        }
    }
    public void healthGoster()
    {
            Debug.Log("Kalan canýnýz : " + getCurrentHealth()); 
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}