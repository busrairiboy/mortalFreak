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
    EnemyGang EnemyGang;
    Health health;
    EnemyAttack attack;

    public Vector2 HiveLocation;
    public Vector2 AttackLocation;
    public Vector2 TargetLocation;

    public bool hasTarget;
    public bool isMoving;
    public int priority = 0;
    void Start()
    {
        attack = GetComponent<EnemyAttack>();
        health=GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        moveEnemy = GetComponent<MoveEnemy>();
        stats = GetComponent<EnemyStats>();
        EnemyGang = transform.parent.gameObject.GetComponent<EnemyGang>();

        health._health = 20;

    }
 
    void Update()
    {
     
        
            TargetLocation=HiveLocation;
            moveToTarget();
           

    }
    public void AttackToPlayer()
    {
        StartCoroutine(attack.Attack());
        
    }
    public void MoveInGang()
    {
        //StartCoroutine(moveEnemy.MoveRandomly(gameObject.GetComponent<Enemy>(),this.gameObject, EnemyGang.transform.position, stats.Speed,EnemyGang.Radius));   
    }
   
    public void moveToTarget() 
    {
        moveEnemy.MoveToTarget(gameObject.GetComponent<Enemy>(), this.gameObject, TargetLocation, stats.Speed);
    }


}
