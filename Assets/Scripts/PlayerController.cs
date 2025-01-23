using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
            float moveX = joystick.Horizontal;
            float moveY = joystick.Vertical;

            Vector2 moveInput = new Vector2(moveX, moveY);
            Vector2 moveVelocity = moveInput.normalized * moveSpeed;

            rb.velocity = moveVelocity;
            Debug.Log("hoppaala");
        }
    }

