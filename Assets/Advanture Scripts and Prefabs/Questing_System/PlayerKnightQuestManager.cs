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
    public GameObject surpriseBox;
    public HealthKnightAdvanturer lifeKnight;
    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                monDBeforeBoss.SetActive(true);
                surpriseBox.SetActive(true);
                Destroy(doTheQuestFirst);
                exp.ModifyExp(quest.experianceReward);
                //lifeKnight.lifes++;
                //TrackLifes.scoreValue++;
                StartCoroutine(DisableQuestText());
            }
        }
    }
    public void GoBattleRunes()
    {
        if (quest.isActive)
        {
            quest.goal.ItemCollected();
            if (quest.goal.IsReached())
            {
                surpriseBox.SetActive(true);
                Destroy(doTheQuestFirst);
                exp.ModifyExp(quest.experianceReward);
                //lifeKnight.lifes++;
                //TrackLifes.scoreValue++;
                StartCoroutine(DisableQuestText());
            }
        }
    }
    IEnumerator DisableQuestText()
    {
        questCompleted.SetActive(true);
        yield return new WaitForSeconds(6f);
        questCompleted.SetActive(false);
    }
}
