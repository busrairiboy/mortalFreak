using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Vector2 TrackPosition;
    public Transform TrackPoint;
    public float TrackRange;
    public bool isTracking;
   
 
    private void Update()
    {
        TrackObject();
    }

    public void TrackObject()
    {

        Collider2D[] gameobject = Physics2D.OverlapCircleAll(TrackPoint.position, TrackRange);
        bool playerFound = false;
        foreach (Collider2D go in gameobject) 
        {
            if (go.CompareTag("Player"))
            {

                TrackPosition = go.transform.position;
                playerFound = true;
                break;

            } 
        }
        if (!playerFound) { isTracking = playerFound; }
    }
    private void OnDrawGizmosSelected()
    {
        if (TrackPoint == null)
            return;
        Gizmos.DrawWireSphere(TrackPoint.position, TrackRange);
    }
}
