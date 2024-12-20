using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGang : MonoBehaviour
{
    public bool isPlayerIn=false;
    public Vector2 PlayerPosition;
    public float Radius;

    private CircleCollider2D Collider;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        Radius = Collider.radius-0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = true;
            
        }
       
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPosition = collision.transform.position;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = false;
            
        }
    }
}