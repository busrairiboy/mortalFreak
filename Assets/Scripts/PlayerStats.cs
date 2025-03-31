using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats :Stats
{//envanter eriþecek

   
    [SerializeField] private float armor_price;
    [SerializeField] private float weapon_price;
    [SerializeField] private string armor_name;
    [SerializeField] private string weapon_name;
    [SerializeField] private float totalDamage;
    
    

    public float TotalDamage { get=> totalDamage; set => totalDamage = value; }
    public float Weapon_Price { get => weapon_price; set => weapon_price = value; }
    public float Armor_Price { get => armor_price; set => armor_price = value; }
    public string Armor_name { get => armor_name; set => armor_name = value; }
    public string Weapon_name { get => weapon_name; set => weapon_name = value; }




}
