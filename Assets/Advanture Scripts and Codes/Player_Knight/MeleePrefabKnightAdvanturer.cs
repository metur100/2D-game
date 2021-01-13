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
            SlimeHealth eHealth = other.gameObject.GetComponent<SlimeHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        if (other.gameObject.tag == "Slime_AI_Patrol")
        {
            SlimeHealthPatrol eHealth = other.gameObject.GetComponent<SlimeHealthPatrol>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
    }
    IEnumerator DestroyGameobject()
    {
        yield return new WaitForSeconds(0.07f);
        Destroy(gameObject);
    }
}