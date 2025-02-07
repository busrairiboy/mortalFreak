using UnityEngine;
using System.Collections.Generic;

public class Healer : MonoBehaviour
{
    [SerializeField] private float healAmount = 10f; 
    [SerializeField] private float healInterval = 2f;//saniye 
    [SerializeField] private float healRadius = 4f; 
    [SerializeField] private LayerMask ally; 

    private float nextHealTime;
    private List<Health> targetsInRange = new List<Health>();
    private CircleCollider2D healingZone;


    void Start()
    {
       
        healingZone = gameObject.AddComponent<CircleCollider2D>();
        healingZone.radius = healRadius;
        healingZone.isTrigger = true;
        nextHealTime = Time.time;
    }


    void Update()
    {
        
       if (Time.time >= nextHealTime)
        {
            HealAlliesInRange();
            nextHealTime = Time.time + healInterval;
        }
    }


    void HealAlliesInRange()
    {
        
        targetsInRange.RemoveAll(target => target == null);

    foreach (Health target in targetsInRange)
        {
            if (!target.IsFullHealth()) 
            {
                target.Heal(healAmount);
                Debug.Log(target.gameObject.name + " hop iyileþtin yaa " + target.GetCurrentHealth());
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
       
       if (((1 << other.gameObject.layer) & ally) != 0)
        {
            Health health = other.GetComponent<Health>();
            if (health != null && !targetsInRange.Contains(health))
            {
                targetsInRange.Add(health);
               
            }
        }

    }



    void OnTriggerExit2D(Collider2D other)
    {
      
        if (((1 << other.gameObject.layer) & ally) != 0)
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                targetsInRange.Remove(health);
                
            }
        }
    }

}

