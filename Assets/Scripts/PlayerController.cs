using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick;
    private Rigidbody2D rb;
    private Health playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        Vector2 moveInput = new Vector2(moveX, moveY);
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;

        rb.velocity = moveVelocity;

        if (moveVelocity.magnitude > 0)
        {
            Debug.Log("hareket ettin ve can barýn dolu");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                playerHealth.TakeDamage(1);
                playerHealth.showCurrentHealth();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                playerHealth.TakeDamage(1);
                playerHealth.showCurrentHealth();
            }
        }
    }
}










