using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    private EnemyStats stats;
    private Health health;
    private EnemyAttack attack;

    public Vector2 HiveLocation;
    public Vector2 AttackLocation;
    public Vector2 TargetLocation;
    public bool isPlayerIn;
    public int priority = 0;

    void Start()
    {

        attack = GetComponent<EnemyAttack>();
        health = GetComponent<Health>();
        moveEnemy = GetComponent<MoveEnemy>();
        stats = GetComponent<EnemyStats>();


        stats.Speed = 1;
        health.SetCurrentHealth(20);
    }

    void Update()
    {
        if (isPlayerIn)
        {
            TargetLocation = AttackLocation;
            moveToTarget();
            AttackToPlayer();
        }
        else
        {
            HiveLocation = stats.HiveLocation;
            TargetLocation = HiveLocation;
            moveToTarget();
        }
    }

    public void AttackToPlayer()
    {
        
        attack.PerformAttack();
    }

    public void moveToTarget()
    {
        moveEnemy.TargetLocation = TargetLocation;
        moveEnemy.speed = stats.Speed;
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
        if (health.GetCurrentHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return health.GetCurrentHealth();
    }
}
