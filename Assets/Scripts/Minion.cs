using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : MonoBehaviour
{
   
    MinionStats stats;   
    MoveMinion moveMinion;
    GameObject Player;
    public Vector2 PlayerPosition;
    public Vector2 HiveLocation;
    public Vector2 TargetLocation;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        stats = GetComponent<MinionStats>();      
        moveMinion = GetComponent<MoveMinion>();
      

        
    }
    private void Update()
    {

        HiveMovement();

    
    }


    private void HiveMovement() {

        PlayerPosition=Player.transform.position;
        moveMinion.TargetLocation = stats.HiveLocation + PlayerPosition ;

    }


}
