using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAttackPrefab : MonoBehaviour
{
    public int bodyAttack = -20;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Knight_Advanturer"))
        {
            HealthKnightAdvanturer eHealth = other.gameObject.GetComponent<HealthKnightAdvanturer>();
            eHealth.ModifyHealth(bodyAttack);
        }
    }
}
