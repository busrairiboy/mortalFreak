using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyGang : MonoBehaviour
{
    public bool isPlayerIn=false;
    public Vector2 PlayerPosition;
    public float Radius;
    public MoveEnemy moveEnemy;

    public bool isMoving;
    public bool hasTarget;
    public Vector2 TargetLocation;

    private CircleCollider2D Collider;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        moveEnemy = GetComponent<MoveEnemy>();
        Radius = Collider.radius-0.5f;
    }
    
    private void Update()
    {
        if (!isMoving)
        {
            MoveInGang();
        }
        
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
    public void MoveInGang()
    {
        StartCoroutine(moveEnemy.MoveRandomly(gameObject.GetComponent<EnemyGang>(),gameObject,1,10));
    }
}