using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ////requiredAmount = PlayerPrefs.GetInt("rA");
        //currentAmount = PlayerPrefs.GetInt("cA");
        //PlayerPrefs.SetInt("cA", currentAmount);
        ////PlayerPrefs.SetInt("cA", requiredAmount);
        currentAmount++;
        TrackQuestProgress.scoreValue += 1;
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