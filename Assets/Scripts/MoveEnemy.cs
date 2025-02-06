using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveEnemy : Move
{
    
    public float speed;
    public Vector2 TargetLocation;

    private void FixedUpdate()
    {      
        MoveToTarget(TargetLocation,speed);
    }
}
