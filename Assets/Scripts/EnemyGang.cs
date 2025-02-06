using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyGang : MonoBehaviour
{

    public MoveEnemy moveEnemy;
    public bool isPlayerIn=false;
    public bool isMoving;
    public bool hasTarget;
    public Vector2 TargetLocation;

    

    private void Start()
    {
        
        moveEnemy = GetComponent<MoveEnemy>();
        
    }


    private void Update()
    {
        if (!isMoving && !isPlayerIn)
        {
            MoveInGang();
        }
        else if (isPlayerIn) 
        {
            return;

           
            }
        }


    

    public void MoveInGang()
    {
        StartCoroutine(moveEnemy.MoveRandomly(gameObject.GetComponent<EnemyGang>(),gameObject,1,10));
    }

    
}