using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    //interface
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    [SerializeField] private float weapon;
    [SerializeField] private float weapon_speed;
    //
   
    public float AttackRange { get=> attackRange; set => attackRange = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Weapon { get => weapon; set => weapon = value; }
    public float Weapon_speed { get => weapon_speed; set => weapon_speed = value; }

    public void ChangeDamage(float value)
    {
        Damage = value;
    }
    public void ChangeAttackRange(float value)
    {
        AttackRange = value;
    }
       
}
