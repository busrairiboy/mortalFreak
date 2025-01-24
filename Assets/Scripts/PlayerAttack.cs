
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public Joystick joystickAttack;
    PlayerStats stats;
    public Transform AttackPoint;
    public LayerMask Enemylayer;
    public float AttackRange;
    public float AttackDamage;
    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        AttackDamage = stats.TotalDamage;
        AttackRange = stats.AttackRange;
    }
    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, Enemylayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(AttackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}