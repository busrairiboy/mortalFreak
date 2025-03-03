using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class HiveCircles : MonoBehaviour
{
    //This script 
    public Vector2 center;
    public float radius = 0.8f;
    public int numberOfCircles = 0;
    
    private void Update()
    {
        center = transform.position;
    }

   public void ArrangeMinionsInCircles(List<GameObject> Minions)
    {
        if (Minions == null || Minions.Count == 0) return;

        List<int> CircleCapacities = new List<int>();

        generateCapacity(CircleCapacities, Minions);
        int circles = CircleCapacities.Count;
        
        for (int i = 0; i < circles; i++) 
        {
            circlePositions(i, Minions, CircleCapacities);
        }
    }

    public void circlePositions(int circleNumber, List<GameObject> Minions, List<int> CircleCapacities)
    {
        float local_radius = radius * (circleNumber + 1); 
        int pass = 0;

       
        for (int i = 0; i < circleNumber; i++)
        {
            pass += CircleCapacities[i];        
        }
       

        int count = CircleCapacities[circleNumber]; 

        
        for (int i = 0; i < count; i++)
        {
            float angle = i * (360f / count);  
            float radian = angle * Mathf.Deg2Rad;

           
            float x = center.x + local_radius * Mathf.Cos(radian);
            float y = center.y + local_radius * Mathf.Sin(radian);

            Vector2 pointPosition = new Vector2(x, y);


            if (i + pass < Minions.Count)
            {
                GameObject minion = Minions[i + pass];

                Stats statsScript = minion.GetComponent<Stats>();
                if (statsScript != null)
                {
                    statsScript.HiveLocation = pointPosition;
                }
            }
        }
    }

    public void generateCapacity(List<int> CircleCapacities, List<GameObject> Minions)
    {
        int first = 5;
        int second = 10;

        CircleCapacities.Add(first);
        CircleCapacities.Add(second);

        int lastCapacity = second;

        while (lastCapacity < Minions.Count)
        {
            lastCapacity += first;
            CircleCapacities.Add(lastCapacity);
            first = second;
            second = lastCapacity;
            lastCapacity = first + second; // Fibonacci mantýðý
        }
    }
}