using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMinion : Move
{
    public float speed;
    public Vector2 TargetLocation;

    private void FixedUpdate()
    {
        MoveToTarget(TargetLocation, speed);
    }
}
