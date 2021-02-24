using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public PlayerMovementAdvanturerKnight moveSpeed;
    public GameObject triggerDialogStart;
    public GameObject triggerGhostDialog;
    public GameObject triggerBeforeFirstBoss;
    public GameObject triggerAfterFirstBoss;
    public GameObject triggerQuestButton;
    public GameObject triggerUpperCave;
    public GameObject activateDialogStart;
    public GameObject activateGhostDialog;
    public GameObject activateDialogBeforeFirstBoss;
    public GameObject activateDialogAfterFirstBoss;
    public GameObject activateDialogUpperCave;
    public GameObject doTheQuestFirst;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MonD_NPC"))
        {
            activateDialogStart.SetActive(true);
            triggerQuestButton.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerDialogStart);
        }
        if (other.CompareTag("MonD_Ghost"))
        {
            activateGhostDialog.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerGhostDialog);
        }
        if (other.CompareTag("MonD_BeforeFirstBoss"))
        {
            activateDialogBeforeFirstBoss.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerBeforeFirstBoss);
        }
        if (other.CompareTag("DoTheQuestFirst"))
        {
            StartCoroutine(WaitTime());
        }
        if (other.CompareTag("MonD_AfterFirstBoss"))
        {
            activateDialogAfterFirstBoss.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerAfterFirstBoss);
        }
        if (other.CompareTag("Dialog_Upper_Cave"))
        {
            activateDialogUpperCave.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerUpperCave);
        }
    }
    IEnumerator WaitTime()
    {
        doTheQuestFirst.SetActive(true);
        yield return new WaitForSeconds(3f);
        doTheQuestFirst.SetActive(false);
    }
}
