using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBrain : MonoBehaviour
{
    GameObject i_brain;
    [SerializeField] GameObject Pgameobject;
    [SerializeField] GameObject enemyObject;
 
    private Health enemy_health;
    private Health player_health;
    
    public virtual void move() { } //sanal kýsýmlar 
    public virtual void Health() { }
    public virtual void Attack0(float damage) { Console.WriteLine("a"); }

    private void Start()
    {
        player_health = Pgameobject.GetComponent<Health>();
        enemy_health = enemyObject.GetComponent<Health>();

    }

    public void CallAttack(float damage)
    {
     
    }
}
