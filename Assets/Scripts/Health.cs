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
            Debug.Log("�LD�N GE�");
            Die();
        }
    }
    public void showCurrentHealth()
    {
        Debug.Log("enemyden hasar al�yorsun ve kalan can�n : " + getCurrentHealth());
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}




