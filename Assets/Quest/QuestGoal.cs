using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class QuestGoal 
{

public GoalType goalType;

public int requiredAmount;
public int currentAmount;

public bool IsReached()
{
    return (currentAmount >= requiredAmount);
}
public void EnemyKilled()
{
    if (goalType == GoalType.Kill)
    currentAmount++;
    
}
public void EnemyKilled2()
{
    if (goalType == GoalType.Kill)
    currentAmount+=2;
}
public void EnemyKilled3()
{
    if (goalType == GoalType.Kill)
    currentAmount+=3;
}
   
}
public enum GoalType
{
    Kill
}