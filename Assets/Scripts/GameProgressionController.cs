using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameProgressionController : MonoBehaviour
{
  
    private void FixedUpdate()
    {
        GameProgressionManager.instance.CollectGangs();
        GameProgressionManager.instance.CollectMinions();
        GameProgressionManager.instance.LevelUpController();
    }

 

}
