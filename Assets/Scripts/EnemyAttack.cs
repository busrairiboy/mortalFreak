using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyStats stats;
    public Transform AttackPoint;
    public LayerMask Playerlayer;
    public float AttackRange;
    public float AttackDamage;
    public bool isAttacking;
  

    private void Start()
    {
        stats = GetComponent<EnemyStats>(); 
    }
    private void Update()
    {
        AttackDamage = stats.Damage;
        AttackRange = stats.AttackRange;
    }

    public IEnumerator Attack()
    {
        if (isAttacking) yield break;
        
        isAttacking = true;
        yield return new WaitForSeconds(1.5f);
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, Playerlayer);
        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Health>().TakeDamage(AttackDamage);
               
        }
        isAttacking = false;
        yield return new WaitForSeconds(1.5f);

    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
