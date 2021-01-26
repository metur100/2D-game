using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonDDialog : MonoBehaviour
{
    public GameObject activateDialog;
    public PlayerMovementAdvanturerKnight moveSpeed;
    public GameObject triggerDialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MonD_NPC"))
        {
            activateDialog.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
        }
        Destroy(triggerDialog);
    }
}