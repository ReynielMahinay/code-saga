using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestLN 
{
    public bool isActive;
    public string title;
    public string description;
    public qcom comp;
    int maxPlatform = 0;
    public QuestGoal goal;
    
    public void CompleteLN()
    {
        isActive = false;
        comp.Setup(maxPlatform);
    }
}
