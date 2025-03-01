using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHive : Hive
{
    
    public AttackToPlayer attackToPlayer;   
    GameObject enemyGang;
    Track track;
    public bool isPlayerIn=false;
    public bool control=false;


    public Vector2 PlayerPosition;


    private new void Start()
    {
        base.Start();
        enemyGang = gameObject.transform.parent.gameObject;//merkezi konum i�in gereklidir.
       // attackToPlayer = GetComponent<AttackToPlayer>();     
        track = GetComponent<Track>();  
             
    }


    private new void Update()
    {
        base.Update();
       
        CollectMinions("Enemy");
        sortEnemiesByPriority();
        Circles();

        if (isPlayerIn)
        {
            control = true;
            SendPlayerPosition(true);
        }
        else if (!isPlayerIn&&!track.isTracking)
        {
              
            SendPlayerPosition(false);
        }
        else if (track.isTracking) 
        {
           
            PlayerPosition=track.TrackPosition;
            SendPlayerPosition(true);
        
        }

    }
    private void FixedUpdate()
    {
        isPlayerIn = attackToPlayer.isPlayerIn;
        PlayerPosition = attackToPlayer.playerPosition;
        if (isPlayerIn)
        {
            control = true;
            SendPlayerPosition(true);
        }
        else if (!isPlayerIn && !track.isTracking)
        {

            SendPlayerPosition(false);
        }
        else if (track.isTracking)
        {

            PlayerPosition = track.TrackPosition;
            SendPlayerPosition(true);

        }
    }


    public void SendPlayerPosition(bool setplayerIn) {
        int count = hive.Count;
        Debug.Log(count);
        for (int i = 0; i < count; i++) 
        {
            hive[i].gameObject.GetComponent<Enemy>().isPlayerIn=setplayerIn;
            hive[i].gameObject.GetComponent<Enemy>().AttackLocation=PlayerPosition;
        }
      
    
    }

    //�ember lokasyonlar�n� di�er scriptten al. burda metotta enemylere tek tek hiveLocation de�erlerine g�nder
    //�emberleri olu�turaca��m�z script ile enemyhive scripti birbirleriyle ileti�im halinde olabilir.
    //�ember ilk halkay� b�nyesinde tutsun di�er halkalar� generete etsin konumlar�n� enemyHive i�inde atal�m. Ka��nc� halkada oldu�u bilgisi enemyHiveda bulunsun ona g�re �ember konumu generate edebiliriz.
    
}
