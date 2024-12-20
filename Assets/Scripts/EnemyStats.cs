using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    private void Update()
    {
        ChangeDamage(0.5f);
        ChangeAttackRange(0.5f);
    }
   
}
