using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnightQuestManager : MonoBehaviour
{
    public Quest quest;
    public ExpKnight exp;
    public GameObject questCompleted;

    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                exp.ModifyExp(quest.experianceReward);
                StartCoroutine(disableQuestText());
            }
        }
    }
    IEnumerator disableQuestText()
    {
        questCompleted.SetActive(true);
        yield return new WaitForSeconds(3f);
        questCompleted.SetActive(false);
    }
}
