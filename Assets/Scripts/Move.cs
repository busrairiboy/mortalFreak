using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour 
{ 
    
   

    protected virtual void MoveToTarget(Vector2 TargetLocation,float speed) 
    {
       
        
        if ((Vector2.Distance(gameObject.transform.position, TargetLocation) > 0.01f))
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetLocation, speed * Time.deltaTime);
        }
       

    }

    public Vector2 GenerateLocation(Vector2 currentPosition, float Range)
    {
        float x = Random.Range(-Range, Range);
        float y = Random.Range(-Range, Range);
        return new Vector2(currentPosition.x + x, currentPosition.y + y);
    }

}
