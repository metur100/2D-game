using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGhostDialog : MonoBehaviour
{
    public GameObject activateDialog;
    public PlayerMovementAdvanturerKnight moveSpeed;
    public GameObject triggerDialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost_Dialog"))
        {
            activateDialog.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
        }
        Destroy(triggerDialog);
    }
}
