using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject activateDialogStart;
    public PlayerMovementAdvanturerKnight moveSpeed;
    public GameObject triggerDialogStart;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MonD_NPC"))
        {
            activateDialogStart.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
        }
        Destroy(triggerDialogStart);
    }
}
