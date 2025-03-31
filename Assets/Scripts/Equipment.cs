using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Equipment : MonoBehaviour
{//player stats, enum
    PlayerStats stats;
    
    private void Start()
    {
        stats = GetComponent<PlayerStats>();
       
       // stats.ChangeDamage(5f);
       // stats.TotalDamage = stats.Damage;
       // stats.AttackRange = 1.3f;
        //stats.Speed = 3;
    }
   
    public void EquipWeapon(float weaponDamage)//maðaza ile ayarlanacak
    {
        stats.Weapon = weaponDamage;
        stats.TotalDamage += stats.Weapon;
    }
    public void EquipArmor() 
    {
    
    }
        
    public float PlayerDamage() {

        return stats.Damage;
    }
}
