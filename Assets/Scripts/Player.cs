using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick joystick;
    private Vector2 input;
    private Rigidbody2D rb;

    private Vector3 Horizontal;
    private Vector3 Vertical;
    private Equipment equipment;
    private PlayerStats Stats;
    private PlayerAttack playerAttack;
    private Health health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
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
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }
}
