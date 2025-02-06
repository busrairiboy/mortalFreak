using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    public float _health
    {
        get => health;
        set => health = value;
    }

    public float getCurrentHealth()
    {
        return health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("ÖLDÜN GEÇ");
            Die();
        }
    }
    public void showCurrentHealth()
    {
        Debug.Log("enemyden hasar alýyorsun ve kalan canýn : " + getCurrentHealth());
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}




