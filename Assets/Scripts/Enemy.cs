using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneTemplate;
using UnityEngine;
using static UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    MoveEnemy moveEnemy;
    EnemyStats stats;
    Health health;
    EnemyAttack attack;

    public Vector2 HiveLocation;
    public Vector2 AttackLocation;
    public Vector2 TargetLocation;

    public bool isPlayerIn;
    public int priority = 0;

    void Start()
    {
        attack = GetComponent<EnemyAttack>();
        health=GetComponent<Health>();      
        moveEnemy = GetComponent<MoveEnemy>();
        stats = GetComponent<EnemyStats>();

        stats.Speed = 1;
        health._health = 20;

    }
 
    void Update()
    {

        if (isPlayerIn)
        {
            TargetLocation = AttackLocation;
            moveToTarget();
            AttackToPlayer();
        }
        else if (!isPlayerIn) 
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
       
        moveEnemy.TargetLocation = TargetLocation;
        moveEnemy.speed=stats.Speed;
    }
  


}
