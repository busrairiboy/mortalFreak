using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public void MoveToTarget(Enemy enemy, GameObject gameObject, Vector2 TargetLocation, float speed)
    {
        enemy.isMoving = true;
        if ((Vector2.Distance(gameObject.transform.position, TargetLocation) > 0.1f))
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, TargetLocation, speed * Time.deltaTime);
        }
        else 
        { 
            enemy.isMoving = false;
            enemy.hasTarget = false;
        }

    }
        
    public IEnumerator MoveRandomly(Enemy enemy,GameObject gameObject, Vector2 ParentLocation,float speed,float Radius)
    {
        enemy.isMoving = true;
        if (!enemy.hasTarget)
        {
            enemy.TargetLocation = generateLocation(ParentLocation,Radius);
            enemy.hasTarget = true;
           
            
        }
        yield return new WaitForSeconds(1.5f);
        while (enemy.hasTarget)
        {
                    
            float distanceToTarget = (Vector2.Distance(gameObject.transform.position,enemy.TargetLocation));

            if (distanceToTarget <= 0.5f) 
            { 
                enemy.isMoving=false;
                enemy.hasTarget = false;

                break;
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemy.TargetLocation, speed * Time.deltaTime);
            yield return null;
        }
        
       
        
        
    
    }

    public Vector2 generateLocation(Vector2 currentPosition,float Range)
        {//Rastgele konum üretir
            float x = Random.Range(-Range, Range);
            float y = Random.Range(-Range, Range);
            return new Vector2(currentPosition.x + x, currentPosition.y + y);
        }

        
    

    }
