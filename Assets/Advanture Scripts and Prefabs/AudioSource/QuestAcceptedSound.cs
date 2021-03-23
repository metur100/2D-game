using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAcceptedSound : MonoBehaviour
{
    public GameObject questAccepted;
    public void QuestSound()
    {
        Instantiate(questAccepted, transform.position, transform.rotation);
    }
}
