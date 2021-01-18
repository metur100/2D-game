using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePrefabKnightAdvanturer : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damageDoneMeleeAttack = -20; //it deals 40 damage close range, 20 damage long range
    private float speedOfMeleeAttack = 100f;

    void Start()
    {
        StartCoroutine(DestroyGameobject());
        rb.velocity = transform.right * speedOfMeleeAttack;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime_AI")
        {
            SlimeHealthPatrol eHealth = other.gameObject.GetComponent<SlimeHealthPatrol>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Slime_AI_2")
        {
            SlimeHealthPatrol2 eHealth = other.gameObject.GetComponent<SlimeHealthPatrol2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Trunk_AI")
        {
            TrunkHealth eHealth = other.gameObject.GetComponent<TrunkHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Trunk_AI_2")
        {
            TrunkHealth2 eHealth = other.gameObject.GetComponent<TrunkHealth2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Trunk_AI_3")
        {
            TrunkHealth3 eHealth = other.gameObject.GetComponent<TrunkHealth3>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Bee_AI")
        {
            BeeHealth eHealth = other.gameObject.GetComponent<BeeHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Snail_AI")
        {
            SnailHealth eHealth = other.gameObject.GetComponent<SnailHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
    }
    IEnumerator DestroyGameobject()
    {
        yield return new WaitForSeconds(0.07f);
        Destroy(gameObject);
    }
}