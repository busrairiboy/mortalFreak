using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHive : Hive
{
    GameObject Player;
    private new void Start()
    {
        base.Start();
      

    }
    private new void Update()
    {
        base.Update();
        CollectMinions("ally");
        sortEnemiesByPriority();
        Circles();
     
    }
 
}
