using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseExpCoin : MonoBehaviour
{
    public int expCollider = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight_Advanturer")
        {
            ExpKnight eHealth = other.gameObject.GetComponent<ExpKnight>();
            eHealth.ModifyHealth(expCollider);
        }
        Destroy(gameObject);
    }
}
