using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMinion : MonoBehaviour
{
    public void move(GameObject gameObject, Vector2 vector, float speed)
    {
        vector = vector - new Vector2(0.5f, 0.5f);
        gameObject.transform.Translate(vector.normalized * Time.deltaTime * speed);

    }


    public void MoveToTarget(Minion minion, GameObject gameObject, Vector2 TargetLocation, float speed)
    {
        minion.isMoving = true;
        Vector2 targetLocationWithDistance = TargetLocation - new Vector2(1, 1);
        if ((Vector2.Distance(gameObject.transform.position, TargetLocation) > 0.1f))
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,targetLocationWithDistance, speed * Time.deltaTime);
        }
        else
        {
            minion.isMoving = false;
            minion.hasTarget = false;
        }

    }
}
