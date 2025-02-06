using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : MonoBehaviour
{
    Rigidbody2D rb;
    MinionStats stats;
    Health health;
    MoveMinion moveMinion;
    MinionAttack minionAttack;
    public Vector2 PlayerPosition;
    Vector2 TargetLocation;

    public bool isMoving;
    public bool hasTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<MinionStats>();
        health = GetComponent<Health>();
        moveMinion = GetComponent<MoveMinion>();
        minionAttack = GetComponent<MinionAttack>();

        PlayerPosition = GameObject.Find("player").transform.position;
    }
    private void Update()
    {
        moveToPlayer();
    
    }


    private void moveToPlayer() {

        moveMinion.MoveToTarget(gameObject.GetComponent<Minion>(), gameObject, PlayerPosition, stats.Speed);

    }


}
