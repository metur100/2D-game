using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleTrigger : MonoBehaviour
{
   public int normalMeleeDmg = -20;

   void OnTriggerEnter2D (Collider2D other)
   {
        if (other.isTrigger != true && other.CompareTag("Player_Ninja"))
        {
            HealthNinja eHealth = other.gameObject.GetComponent<HealthNinja>();
            eHealth.ModifyHealth(normalMeleeDmg);
        }
        else if (other.isTrigger != true && other.CompareTag("Player_Hunter"))
        {
            HealthHunter eHealth = other.gameObject.GetComponent<HealthHunter>();
            eHealth.ModifyHealth(normalMeleeDmg);
        }
        else if (other.isTrigger != true && other.CompareTag("Player_Knight"))
        {
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(normalMeleeDmg);
        }
    }
}
