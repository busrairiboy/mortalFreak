using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHive : MonoBehaviour
{
    public List<GameObject> enemyHive = new List<GameObject>();
    AttackToPlayer attackToPlayer;
    HiveCircles hiveCircles;
    GameObject enemyGang;
    EnemyGang Gang;

    public Vector2 PlayerPosition;
    private void Start()
    {
        enemyGang = gameObject.transform.parent.gameObject;
        attackToPlayer = GetComponent<AttackToPlayer>();
        Gang=GetComponent<EnemyGang>();
        hiveCircles=GetComponent<HiveCircles>();
             
    }


    private void Update()
    {
        PlayerPosition = attackToPlayer.playerPosition;

        CollectEnemiesFromGang();
        sortEnemiesByPriority();

        Circles();

        if (attackToPlayer.isPlayerIn)
        {
            Gang.isPlayerIn = true;
            SendPlayerPosition(true);
        }
        else if (!attackToPlayer.isPlayerIn) 
        {
            Gang.isPlayerIn= false;
            SendPlayerPosition(false);
        }
       


    }


    public void Circles() 
    {
        hiveCircles.firstCircle(enemyHive);
       
        if (enemyHive.Count > 5 & enemyHive.Count<=15) 
        {
            genereteCircle(2,5);
        }
       if (enemyHive.Count > 15 & enemyHive.Count <= 40)
        {
            genereteCircle(3, 15);
        }

    }
    
    public void genereteCircle(int circleNumbers,int pass) 
    {
        hiveCircles.GenereteCircle(circleNumbers,enemyHive,pass);
    }


    public void SendPlayerPosition(bool setplayerIn) {
        int count = enemyHive.Count;

        for (int i = 0; i < count; i++) 
        {
            enemyHive[i].gameObject.GetComponent<Enemy>().isPlayerIn=setplayerIn;
            enemyHive[i].gameObject.GetComponent<Enemy>().AttackLocation=PlayerPosition;
        }
      
    
    }

    public void CollectEnemiesFromGang()
    {

        Transform[] childTransforms =enemyGang.GetComponentsInChildren<Transform>();

        foreach (Transform child in childTransforms) {

            if (child.CompareTag("Enemy") && !enemyHive.Contains(child.gameObject)) {
                enemyHive.Add(child.gameObject);
            }
        
        }

    }

    public void sortEnemiesByPriority() {
        
        enemyHive.Sort((enemy1, enemy2) => enemy2.GetComponent<Enemy>().priority.CompareTo(enemy1.GetComponent<Enemy>().priority));

    }
    //�ember lokasyonlar�n� di�er scriptten al. burda metotta enemylere tek tek hiveLocation de�erlerine g�nder
    //�emberleri olu�turaca��m�z script ile enemyhive scripti birbirleriyle ileti�im halinde olabilir.
    //�ember ilk halkay� b�nyesinde tutsun di�er halkalar� generete etsin konumlar�n� enemyHive i�inde atal�m. Ka��nc� halkada oldu�u bilgisi enemyHiveda bulunsun ona g�re �ember konumu generate edebiliriz.
    
}
