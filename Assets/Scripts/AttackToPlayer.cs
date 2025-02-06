using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToPlayer : MonoBehaviour
{
    public bool isPlayerIn;
    public Vector2 playerPosition;

    Track track;

    private void Start()
    {
        track = GetComponent<Track>();  
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = true;
            

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerIn = false;
            track.isTracking = true;
            
           
        }
    }

}
