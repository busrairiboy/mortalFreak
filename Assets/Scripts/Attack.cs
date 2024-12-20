using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool isAttackOn = false;
    private float Damage ;
    
    public void attack(bool isAttackOn,float damage)
    {
        this.isAttackOn = isAttackOn;
        this.Damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isAttackOn)
        {
            if (other.CompareTag("enemy"))
            {
                Debug.Log("enemy"+Damage);
            }
        }
      
    }
    
    //
}
