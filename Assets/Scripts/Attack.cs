using UnityEngine;

public class Attack : MonoBehaviour
{
   
    protected bool isAttackOn = false;
    protected float damage = 10f;

   
    public Transform attackPoint;
    public float attackRange = 1f;

    protected virtual void Awake()
    {
        
        if (attackPoint == null)
        {
            attackPoint = transform;
        }
    }

    public virtual void InitializeAttack(bool isAttackOn, float damage)
    {
        this.isAttackOn = isAttackOn;
        this.damage = damage;
    }

    
    public virtual void PerformAttack()
    {
        Debug.Log(" attack  " + damage);
    }

    
    protected virtual void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}