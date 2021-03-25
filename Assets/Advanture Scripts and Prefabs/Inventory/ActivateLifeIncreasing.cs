using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLifeIncreasing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            FindObjectOfType<AudioManager>().Play("Life_Item");
            HealthKnightAdvanturer life = collision.gameObject.GetComponent<HealthKnightAdvanturer>();
            life.lifes++;
            TrackLifes.scoreValue++;
        }
        Destroy(gameObject);
    }
}