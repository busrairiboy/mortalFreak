using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 Horizontal;
    private Vector3 Vertical;
    private Equipment equipment;
    private PlayerStats Stats;
    private PlayerAttack playerAttack;
    private Health health;
   
    void Start()
    {
        health = GetComponent<Health>();
        equipment = GetComponent<Equipment>();
        Stats = GetComponent<PlayerStats>();
        playerAttack = GetComponent<PlayerAttack>();

        health._health = 60;

      

    }

    
    void Update()
    {
        Stats.Armor= 5.0f;
        
        if(Input.GetKey(KeyCode.A)) {
            Horizontal = new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Horizontal = new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vertical = new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vertical = new Vector3(0, 1, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
           
            Horizontal= Vector3.zero;   
        }
        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) 
        {
            Vertical = Vector3.zero;

        }
            Move.Instance.move(this.gameObject,(Horizontal+Vertical),Stats.Speed);
        
        if (Input.GetMouseButtonDown(0)) {
            
            playerAttack.Attack();
        }

    }


    void BeyiniCagir()
    {
        //IBrain.Instance.CallAttack(equipment.PlayerDamage());

    }

}
