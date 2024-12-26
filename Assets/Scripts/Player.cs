using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
  
    public FixedJoystick joystick;
    
    private Vector2 input;

    private Rigidbody2D rb;
    private Equipment equipment;
    private PlayerStats Stats;
    private PlayerAttack playerAttack;
    private Health health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        equipment = GetComponent<Equipment>();
        Stats = GetComponent<PlayerStats>();
        playerAttack = GetComponent<PlayerAttack>();

        health._health = 60;
    }

    void Update()
    {
        Stats.Armor = 5.0f;
        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;
        Debug.Log($"Joystick Values - Horizontal: {input.x}, Vertical: {input.y}");
    }

    private void FixedUpdate()
    {
        rb.velocity = input * Stats.Speed;
    }
}
