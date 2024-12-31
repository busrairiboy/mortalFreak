using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    private CircleCollider2D Collider;
    EnemyHive enemyHive;

    public bool isPlayerIn;
    public Vector2 playerPosition;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        enemyHive = GetComponent<EnemyHive>();
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
            playerPosition = collision.transform.position;

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
