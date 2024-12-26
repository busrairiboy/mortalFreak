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
        
    public IEnumerator MoveRandomly(EnemyGang enemygang,GameObject gameObject,float speed,float Radius)
    {
        enemygang.isMoving = true;
        if (!enemygang.hasTarget)
        {
            enemygang.TargetLocation = GenerateLocation(gameObject.transform.position, Radius);
            enemygang.hasTarget = true;
           
            
        }
        yield return new WaitForSeconds(1.5f);
        while (enemygang.hasTarget)
        {
                    
            float distanceToTarget = (Vector2.Distance(gameObject.transform.position,enemygang.TargetLocation));

            if (distanceToTarget <= 0.5f) 
            { 
                enemygang.isMoving=false;
                enemygang.hasTarget = false;

                break;
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemygang.TargetLocation, speed * Time.deltaTime);
            yield return null;
        }
        
       
        
        
    
    }


    public IEnumerator MoveRandomly0(GameObject gameObject,  float speed, float range, float stopDistance = 0.5f)
    {
       
        while (true)
        {
           
            Vector2 targetLocation = GenerateLocation(gameObject.transform.position, range);

          
            while (true)
            {
                
                float distanceToTarget = Vector2.Distance(gameObject.transform.position, targetLocation);

                
                if (distanceToTarget <= stopDistance)
                {
                    break;
                }

                
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetLocation, speed * Time.deltaTime);

                
                yield return null;
            }

            
            yield return new WaitForSeconds(1.5f);
        }
    }



    public Vector2 GenerateLocation(Vector2 currentPosition,float Range)
        {//Rastgele konum üretir
            float x = Random.Range(-Range, Range);
            float y = Random.Range(-Range, Range);
            return new Vector2(currentPosition.x + x, currentPosition.y + y);
        }

        
    

    }
