using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLifeIncreasing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            HealthKnightAdvanturer life = collision.gameObject.GetComponent<HealthKnightAdvanturer>();
            life.lifes++;
            TrackLifes.scoreValue += 1;
        }
        Destroy(gameObject);
    }
}