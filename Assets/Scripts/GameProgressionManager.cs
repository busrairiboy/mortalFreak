using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameProgressionManager : MonoBehaviour
{
    public static  GameProgressionManager instance;
   
    public static GameProgressionManager Instance
    {
        get 
        {
            if (instance == null) 
            { 
            
            }
            return instance;
        }
                     
    }
    private void Awake()
    {
        instance = this;    
    }

    public List<Transform> Gangs = new List<Transform>();
    public List<GameObject> minions = new List<GameObject>();

    public int playerXP;
    public Features level_1_Warrior;
    public Features level_2_Warrior;
    public Features level_3_Warrior;
    public Features level_2_Tank;
    public Features level_2_Archer;
    public Features level_2_Wizard;
    public Features level_2_Suport;

    public int CurrentGameLevel() 
    {
        if (playerXP < 10)
        {
            return 1;
        }
        else if (playerXP >= 10 && playerXP < 25) 
        {
            return 2;
        }
        else if (playerXP >=25)
        {
            return 3;
        }
        return 1 ;

    }
    public void CollectGangs()
    {
        GameObject[] gangs = GameObject.FindGameObjectsWithTag("Gang");

        
        Gangs.RemoveAll(gang => gang == null);

        foreach (GameObject gang in gangs)
        {
            if (!Gangs.Contains(gang.transform))
            {
                Gangs.Add(gang.transform);
            }
        }
    }

    public void CollectMinions()
    {
        
        minions.RemoveAll(minion => minion == null);

        foreach (Transform gang in Gangs)
        {
            
            if (gang == null) continue;

            foreach (Transform child in gang)
            {
                if (child.CompareTag("Enemy") || child.CompareTag("ally"))
                {
                    if (!minions.Contains(child.gameObject))
                    {
                        minions.Add(child.gameObject);
                    }
                }
            }
        }
    }
    public void LevelUpController() 
    {
       
        foreach (GameObject minion in minions) 
        {
            DefineMinionType(minion);
            
        }
    
    }

    public void DefineMinionType(GameObject go) 
    {
        int levelStatus= CurrentGameLevel();
        Stats stats = go.GetComponent<Stats>();
        int goPriority = stats.priority;
        
        if (levelStatus == 2) 
        {
            if (goPriority == 1) 
            { 
                stats.features= level_2_Warrior;
                stats.AssignStats();
            }

          
        }
        
    
    }



    //sahnedeki tüm gangleri toplicak ve bu ganglerin altýndaki child enemylere eriþecek //gangController
    //eriþtiði enemynin kodunu tutucak ve prefabý silip yerine kodun 2.levelinin prefabýný instantiate edicek









}
