using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public HealthKnightAdvanturer health;
    [SerializeField]
    private int healing = 20;
    public GameObject healEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            HealthKnightAdvanturer eHealth = collision.gameObject.GetComponent<HealthKnightAdvanturer>();
            eHealth.ModifyHealth(healing);
            Instantiate(healEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}