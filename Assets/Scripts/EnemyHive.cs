using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHive : Hive
{
    
    AttackToPlayer attackToPlayer;   
    GameObject enemyGang;
    Track track;


    public Vector2 PlayerPosition;


    private new void Start()
    {
        base.Start();
        enemyGang = gameObject.transform.parent.gameObject;//merkezi konum i�in gereklidir.
        attackToPlayer = GetComponent<AttackToPlayer>();     
        track = GetComponent<Track>();  
             
    }


    private new void Update()
    {
        base.Update();
        PlayerPosition = attackToPlayer.playerPosition;//metotla�t�r

        CollectMinions("Enemy");
        sortEnemiesByPriority();
        Circles();

        if (attackToPlayer.isPlayerIn)
        {
            SendPlayerPosition(true);
        }
        else if (!attackToPlayer.isPlayerIn&&!track.isTracking)
        {
            SendPlayerPosition(false);
        }
        else if (track.isTracking) 
        {
            PlayerPosition=track.TrackPosition;
            SendPlayerPosition(true);
        
        }

    }

   
  
    public void SendPlayerPosition(bool setplayerIn) {
        int count = hive.Count;

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
