using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleTrigger : MonoBehaviour
{
   private int maleDmg = -20;

   void OnTriggerEnter2D (Collider2D other)
   {
        if (other.isTrigger != true && other.CompareTag("Player_Njinja"))
        {
            HealthNjinja eHealth = other.gameObject.GetComponent<HealthNjinja>();
            eHealth.ModifyHealth(maleDmg);
        }
    }
}
