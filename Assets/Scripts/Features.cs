using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create", menuName = "Feature")]
public class Features : ScriptableObject
{
    public int Health;
    public int Damage;
    public float Speed;
    public float armor;
    public int priority;
    public float attackRange;
    public Sprite GameArt;
    public Animation animation;
}

 
