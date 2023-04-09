using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager singleton;

    public int waterNeeded, waterCollected;
    public bool canEnter;
    
    private void Awake() {
        singleton = this;
    }

    public void CollectWater(){
        waterCollected++;
        if(waterCollected >= waterNeeded){
            canEnter = true;
        }
    }

    
}
