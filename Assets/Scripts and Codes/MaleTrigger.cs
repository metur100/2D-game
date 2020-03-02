using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleTrigger : MonoBehaviour
{
   int dmg = -20;

   void OnTriggerEnter2D (Collider2D other)
   {
        if (other.isTrigger != true && other.gameObject.tag == "Player_Njinja")
        {
            // other.SendMessageUpwards("ModifyHealth", dmg);
            HealthNjinja eHealth = other.gameObject.GetComponent<HealthNjinja>();
            eHealth.ModifyHealth(dmg);
            //gameObject.GetComponent<Animation>().Play("Njinja_Hurt");
        }
    }
}
