using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHive : MonoBehaviour
{
    public List<GameObject> enemyHive = new List<GameObject>();

    HiveCircles hiveCircles;
    

    private void Start()
    {
        hiveCircles=GetComponent<HiveCircles>();
        CollectEnemiesFromGang(gameObject.transform.parent.gameObject);
        sortEnemiesByPriority();
        
    }


    private void Update()
    {
        CollectEnemiesFromGang(gameObject.transform.parent.gameObject);
        sortEnemiesByPriority();

        Circles();
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




    public void CollectEnemiesFromGang(GameObject enemyGang)
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
    //çember lokasyonlarýný diðer scriptten al. burda metotta enemylere tek tek hiveLocation deðerlerine gönder
    //çemberleri oluþturacaðýmýz script ile enemyhive scripti birbirleriyle iletiþim halinde olabilir.
    //çember ilk halkayý bünyesinde tutsun diðer halkalarý generete etsin konumlarýný enemyHive içinde atalým. Kaçýncý halkada olduðu bilgisi enemyHiveda bulunsun ona göre çember konumu generate edebiliriz.
    
}
