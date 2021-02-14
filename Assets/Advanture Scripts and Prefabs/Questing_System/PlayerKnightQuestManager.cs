using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnightQuestManager : MonoBehaviour
{
    public Quest quest;
    public ExpKnight exp;
    public GameObject questCompleted;
    public GameObject monDBeforeBoss;
    public GameObject doTheQuestFirst;

    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                monDBeforeBoss.SetActive(true);
                Destroy(doTheQuestFirst);
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
