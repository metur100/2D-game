using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    //public GameObject enemy;
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
    public void EnemyKilled()
    {
        //if (goalType == GoalType.Kill)
        //{
        //    if(enemy.gameObject.CompareTag("Slime_AI") == true)
        //    {
        currentAmount++;
        //    }
        //}    
    }
    public void ItemCollected()
    {
        if (goalType == GoalType.Gethering)
            currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    Gethering
}