using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    //scriptableobaject
    //interface

    [SerializeField] bool isLevel2=false;
    [SerializeField] bool isLevel3=false;

    public Features features_level1;
    public Features features_level2;
    public Features features_level3;

    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    [SerializeField] private float weapon;
    [SerializeField] private float weapon_speed;
    [SerializeField] public int priority;
    [SerializeField] public Vector2 HiveLocation;
    //

    private void Start()
    {
        AssignStats(features_level1);
    }
    private void Update()
    {
        ChangeLevel();//updatesiz event ile yapmanýn yolunu bul
    }
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

    public void AssignStats(Features features) 
    {

        damage = features.Damage;
        speed=features.Speed;
        attackRange = features.attackRange;
        priority= features.priority;
        armor=features.armor;

    
    }
    public void ChangeLevel() 
    {
        if (isLevel2)
        { AssignStats(features_level2); }
        else if (isLevel3) 
        { AssignStats(features_level3); }
    
    }
       
}
