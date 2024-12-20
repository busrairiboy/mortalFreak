using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
//movelar ayrýlacak

{
    private static Move instance;
    public static Move Instance
    {

        get { return instance; }
        set { instance = value; }

    }

    public Move()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void move(GameObject gameObject, Vector3 vector3, float speed)
    {
        gameObject.transform.Translate(vector3.normalized * Time.deltaTime * speed);

    }
}
   
  /*     
    public void MoveToTarget(GameObject gameObject,Enemy enemy,Vector2 targetLoc,float speed)
    {
        enemy.isMoving = false;
        if (!enemy.hasTarget)
        {
              enemy.target_location= targetLoc-new Vector2(1,1);
              //enemy.hasTarget = true;
                
        }

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemy.target_location, speed * Time.deltaTime);

        if (Vector2.Distance(gameObject.transform.position, enemy.target_location) < 0.1f)
        {
              enemy.hasTarget = false;
                
        }
        
        
    }
    public Vector2 generateLocation(Vector2 currentPosition)
    {//Rastgele konum üretir
        float x = Random.Range(-3, 3);
        float y = Random.Range(-3, 3);
        return new Vector2(currentPosition.x + x, currentPosition.y + y);
    }

    public IEnumerator MoveRandom_Delay(GameObject gameObject, Enemy enemy, Vector2 targetLoc, float speed, Vector2 parentLoc)
    {//Bu metot enemyler için kendi alanlarýnda rastgele hareket etmelerini saðlar.Her hareketten sonra 1,5saniye beklerler.
        enemy.isMoving = true;
        
        if (!enemy.hasTarget)
        {
            enemy.target_location = generateLocation(parentLoc);
            enemy.hasTarget = true;
            

        }
        while (Vector2.Distance(gameObject.transform.position, enemy.target_location) > 0.1f)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemy.target_location, speed * Time.deltaTime);
            yield return null; 
        }
       
        yield return new WaitForSeconds(1.5f);
        
        if (Vector2.Distance(gameObject.transform.position, enemy.target_location) < 0.1f)
        {
            enemy.hasTarget = false;
            enemy.isMoving=false;

        }

    }

}
*/