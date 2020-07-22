using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleTrigger : MonoBehaviour
{
   private int maleDmg = -20;

   void OnTriggerEnter2D (Collider2D other)
   {
        if (other.isTrigger != true && other.gameObject.tag == "Player_Njinja")
        {
            // other.SendMessageUpwards("ModifyHealth", dmg);
            HealthNjinja eHealth = other.gameObject.GetComponent<HealthNjinja>();
            eHealth.ModifyHealth(maleDmg);
            //gameObject.GetComponent<Animation>().Play("Njinja_Hurt");
        }
    }
}
