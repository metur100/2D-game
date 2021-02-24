using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger2 : MonoBehaviour
{
    public GameObject triggerUpperCave;
    public GameObject activateDialogUpperCave;
    public GameObject triggerLowerCave;
    public GameObject activateDialogLowerCave;
    public PlayerMovementAdvanturerKnight moveSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialog_Upper_Cave"))
        {
            activateDialogUpperCave.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerUpperCave);
        }
        if (collision.CompareTag("Dialog_Lower_Cave"))
        {
            activateDialogLowerCave.SetActive(true);
            moveSpeed.normalMovementSpeed = 0f;
            Destroy(triggerLowerCave);
        }
    }
}
