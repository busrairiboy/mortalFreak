using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveCircles : MonoBehaviour
{
    public Vector2 center;
    public float radius = 0.8f;
    public int numberOfPoints = 5;//sýkýntý çýkarýyor küçük guruplara adapte etme konusunda ilerde sorun yapýcak
    
    private void Update()
    {
        center = transform.position;
    }

    public void firstCircle(List<GameObject> Minions) 
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            
            float angle = i * (360f / numberOfPoints);

          
            float radian = angle * Mathf.Deg2Rad;

            
            float x = center.x + radius * Mathf.Cos(radian);
            float y = center.y + radius * Mathf.Sin(radian);

            
            Vector2 pointPosition = new Vector2(x, y);
            GameObject minion = Minions[i]; 
            Stats statsScript = minion.GetComponent<Stats>();

            if (statsScript != null)
            {
                statsScript.HiveLocation = pointPosition;
            }
            
            
        }

    }

    public void GenereteCircle(int circlenumber,List<GameObject> Minions, int pass) 
    {
        //int points = numberOfPoints*circlenumber;
        float local_radius = radius * circlenumber;

        int count=(Minions.Count-pass);

        for (int i = 0; i < count ; i++) 
        {
            float angle = i * (360f / count);

            float radian = angle * Mathf.Deg2Rad;


            float x = center.x + local_radius * Mathf.Cos(radian);
            float y = center.y + local_radius * Mathf.Sin(radian);


            Vector2 pointPosition = new Vector2(x, y);
            GameObject minion= Minions[i+pass];
            Stats statsScript = minion.GetComponent<Stats>();

            if (statsScript != null)
            {
                statsScript.HiveLocation = pointPosition;
            }

        }
    }
    

}
