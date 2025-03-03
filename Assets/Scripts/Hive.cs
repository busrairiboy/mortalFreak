using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Hive : MonoBehaviour
{
    public List<GameObject> hive  = new List<GameObject>();
    HiveCircles hiveCircles;
    GameObject ParentObject;

    protected virtual void Start()
    {
      
       
        hiveCircles = GetComponent<HiveCircles>();
       

    }
    protected virtual void Update()
    {
        ParentObject = gameObject.transform.parent.gameObject;
    }
    protected virtual void Circles()
    {
        hiveCircles.ArrangeMinionsInCircles(hive);
     

    }
  
    protected virtual void CollectMinions(string hiveObject)
    {

        Transform[] childTransforms = ParentObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in childTransforms)
        {

            if (child.CompareTag(hiveObject) && !hive.Contains(child.gameObject))
            {
                hive.Add(child.gameObject);
            }

        }

    }
    protected virtual void sortEnemiesByPriority()
    {

        hive = hive.OrderByDescending(obj => obj.GetComponent<Stats>().priority)
               .ThenBy(obj => hive.IndexOf(obj)) // Orijinal sýralamayý korumak için
               .ToList();
    }
}
