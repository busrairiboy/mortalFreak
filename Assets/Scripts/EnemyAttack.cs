using System.Collections;
using UnityEngine;

public class EnemyAttack : Attack
{
    
    private EnemyStats stats;
    public LayerMask playerLayer;
    private bool isAttacking;

    protected override void Awake()
    {
        base.Awake(); 
    }

    private void Start()
    {
        stats = GetComponent<EnemyStats>();

        if (stats != null)
        {
            attackRange = stats.AttackRange;
            damage = stats.Damage;
        }
    }

    private void Update()
    {
        if (stats != null)
        {
            
            damage = stats.Damage;
            attackRange = stats.AttackRange;
        }
    }


    public override void PerformAttack()
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1.5f);

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayers)
        {
            Health health = player.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }


    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}