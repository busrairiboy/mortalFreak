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
        enemyGang = gameObject.transform.parent.gameObject;//merkezi konum için gereklidir.
        attackToPlayer = GetComponent<AttackToPlayer>();     
        track = GetComponent<Track>();  
             
    }


    private new void Update()
    {
        base.Update();
        PlayerPosition = attackToPlayer.playerPosition;//metotlaþtýr

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

    //çember lokasyonlarýný diðer scriptten al. burda metotta enemylere tek tek hiveLocation deðerlerine gönder
    //çemberleri oluþturacaðýmýz script ile enemyhive scripti birbirleriyle iletiþim halinde olabilir.
    //çember ilk halkayý bünyesinde tutsun diðer halkalarý generete etsin konumlarýný enemyHive içinde atalým. Kaçýncý halkada olduðu bilgisi enemyHiveda bulunsun ona göre çember konumu generate edebiliriz.
    
}
