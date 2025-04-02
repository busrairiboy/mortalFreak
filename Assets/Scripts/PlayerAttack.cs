using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
    public Joystick joystickAttack;
    PlayerStats stats;
    public LayerMask enemyLayer;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();

        attackRange = stats.AttackRange;
    }

    private void Update()
    {
       
        damage = stats.TotalDamage;
        attackRange = stats.AttackRange;
    }

    public override void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(damage);
        }
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}