using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeneathPlatformDeath : MonoBehaviour
{
    public int death = -500;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight_Advanturer")
        {
            HealthKnightAdvanturer eHealth = other.gameObject.GetComponent<HealthKnightAdvanturer>();
            eHealth.ModifyHealth(death);
        }
    }
}
