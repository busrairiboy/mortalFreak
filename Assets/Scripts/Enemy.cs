using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneTemplate;
using UnityEngine;
using static UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    MoveEnemy moveEnemy;
    EnemyStats stats;
   
    Health health;
    EnemyAttack attack;

    public Vector2 HiveLocation;
    public Vector2 AttackLocation;
    public Vector2 TargetLocation;

    public bool isPlayerIn;
    public bool hasTarget=false;
    public bool isMoving;
    public int priority = 0;
    void Start()
    {
        attack = GetComponent<EnemyAttack>();
        health=GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        moveEnemy = GetComponent<MoveEnemy>();
        stats = GetComponent<EnemyStats>();
        
        health._health = 20;

    }
 
    void Update()
    {


        if (isPlayerIn){hasTarget = true;}
        else if (!isPlayerIn) { hasTarget = false; }

        if (hasTarget)
        {
            TargetLocation = AttackLocation;
            moveToTarget();
            AttackToPlayer();
        }
        else if (!hasTarget) 
        {
            TargetLocation = HiveLocation;
            moveToTarget();
        }
       
           

        
       
           

    }
    public void AttackToPlayer()
    {
        StartCoroutine(attack.Attack());
        
    }
   
    public void moveToTarget() 
    {
        moveEnemy.MoveToTarget(gameObject.GetComponent<Enemy>(), this.gameObject, TargetLocation, stats.Speed);
    }


}
