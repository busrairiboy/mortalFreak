using UnityEngine;
using System.Collections.Generic;

public class Healer : MonoBehaviour
{
    [SerializeField] private float healAmount = 10f;
    [SerializeField] private float healInterval = 2f; //aral�k
    [SerializeField] private float healRadius = 4f;
    [SerializeField] private LayerMask ally;

    private float nextHealTime;

    private List<Health> targetsInRange = new List<Health>();
    private CircleCollider2D healingZone;

    [SerializeField] private float health = 100f; 
    //[SerializeField] private float damageAmount = 10f; 

    void Start()
    {
       
        Debug.Log("Healer alanda  " + health);
        healingZone = gameObject.AddComponent<CircleCollider2D>();
        healingZone.radius = healRadius;
        healingZone.isTrigger = true;
        nextHealTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextHealTime){
            HealAlliesInRange();
            nextHealTime = Time.time + healInterval;
        }
    }

    void HealAlliesInRange()
    {
        targetsInRange.RemoveAll(target => target == null);

        foreach (Health target in targetsInRange){
            if (target != null && !target.IsFullHealth()){
                target.Heal(healAmount);
                Debug.Log(target.gameObject.name + " hop iyile�tin yaa " + target.GetCurrentHealth());
     }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (((1 << other.gameObject.layer) & ally) != 0){
            Health health = other.GetComponent<Health>();
            if (health != null && !targetsInRange.Contains(health)){
                targetsInRange.Add(health);
   }
 }
    }

    void OnTriggerExit2D(Collider2D other){
        if (((1 << other.gameObject.layer) & ally) != 0){
            Health health = other.GetComponent<Health>();
            if (health != null){
                targetsInRange.Remove(health);
 }
        }
    }

   
    public void TakeDamage(int amount){
        health -= amount; 
        if (health <= 0){
            Die(); 
        }
 }


    private void Die(){
        Debug.Log("Healer �ld�");
        Destroy(gameObject); 
    }
}
