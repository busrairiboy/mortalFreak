using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hive : MonoBehaviour
{
    public List<GameObject> hive = new List<GameObject>();
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
    protected virtual void Circles() //sayýya göre otamatik kendisi circlelarý oluþturacak bir sistem lazým
    {
        hiveCircles.firstCircle(hive);

        if (hive.Count > 5 & hive.Count <= 15)
        {
            genereteCircle(2, 5);
        }
        if (hive.Count > 15 & hive.Count <= 40)
        {
            genereteCircle(3, 15);
        }

    }
    protected virtual void genereteCircle(int circleNumbers, int pass)
    {
        hiveCircles.GenereteCircle(circleNumbers, hive, pass);
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

        hive.Sort((obj1, obj2) => obj2.GetComponent<Stats>().priority.CompareTo(obj1.GetComponent<Stats>().priority));

    }
}
