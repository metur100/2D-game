using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseExpCoin : MonoBehaviour
{
    public int expCollider;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Knight_Advanturer"))
        {
            FindObjectOfType<AudioManager>().Play("Exp_Item");
            ExpKnight eHealth = other.gameObject.GetComponent<ExpKnight>();
            eHealth.ModifyExp(expCollider);
        }
        Destroy(gameObject);
    }
}
