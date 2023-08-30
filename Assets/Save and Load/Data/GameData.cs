using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public int healthCount;
    public int CurrentCount; // Crystal number;
    public Vector3 playerPosition;
    public string currentSceneName;


    public GameData(){
        this.healthCount = 6;
        this.CurrentCount = 0;
        playerPosition = Vector3.zero;
        currentSceneName = " ";
    }

}
