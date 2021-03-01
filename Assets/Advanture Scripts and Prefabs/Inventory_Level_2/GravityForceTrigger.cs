using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForceTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            PlayerMovementAdvanturerKnight speedBoost = collision.gameObject.GetComponent<PlayerMovementAdvanturerKnight>();
            speedBoost.rb.gravityScale = 10f;
        }
        Destroy(gameObject);
    }
}