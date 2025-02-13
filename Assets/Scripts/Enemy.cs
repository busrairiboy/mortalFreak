using UnityEngine;

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
        else if (!isPlayerIn)
        {
            HiveLocation = stats.HiveLocation;
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

   //enemy.healthe eriþemedðimden getter kullanýldý.
    public float GetHealth()
    {
        return health.GetCurrentHealth();
    }
}
