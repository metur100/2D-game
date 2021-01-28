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
        else if (other.gameObject.tag == "Slime_AI_3")
        {
            SlimeHealthPatrol3 eHealth = other.gameObject.GetComponent<SlimeHealthPatrol3>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Slime_AI_4")
        {
            SlimeHealthPatrol4 eHealth = other.gameObject.GetComponent<SlimeHealthPatrol4>();
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
        else if (other.gameObject.tag == "Trunk_AI_4")
        {
            TrunkHealth4 eHealth = other.gameObject.GetComponent<TrunkHealth4>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Trunk_AI_5")
        {
            TrunkHealth5 eHealth = other.gameObject.GetComponent<TrunkHealth5>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Trunk_AI_6")
        {
            TrunkHealth6 eHealth = other.gameObject.GetComponent<TrunkHealth6>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Bee_AI")
        {
            BeeHealth eHealth = other.gameObject.GetComponent<BeeHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Bee_AI_2")
        {
            BeeHealth2 eHealth = other.gameObject.GetComponent<BeeHealth2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Snail_AI")
        {
            SnailHealth eHealth = other.gameObject.GetComponent<SnailHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Snail_AI_2")
        {
            SnailHealth2 eHealth = other.gameObject.GetComponent<SnailHealth2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Snail_AI_3")
        {
            SnailHealth3 eHealth = other.gameObject.GetComponent<SnailHealth3>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Snail_AI_4")
        {
            SnailHealth4 eHealth = other.gameObject.GetComponent<SnailHealth4>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Turtle_AI")
        {
            TurtleHealth eHealth = other.gameObject.GetComponent<TurtleHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Turtle_AI_2")
        {
            TurtleHealth2 eHealth = other.gameObject.GetComponent<TurtleHealth2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Turtle_AI_3")
        {
            TurtleHealth3 eHealth = other.gameObject.GetComponent<TurtleHealth3>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "BlueBird_AI")
        {
            BlueBirdHealth eHealth = other.gameObject.GetComponent<BlueBirdHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "BlueBird_AI_2")
        {
            BlueBirdHealth2 eHealth = other.gameObject.GetComponent<BlueBirdHealth2>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "BlueBird_AI_3")
        {
            BlueBirdHealth3 eHealth = other.gameObject.GetComponent<BlueBirdHealth3>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Ghost_AI")
        {
            GhostHealth eHealth = other.gameObject.GetComponent<GhostHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
        else if (other.gameObject.tag == "Bat_AI")
        {
            BatHealth eHealth = other.gameObject.GetComponent<BatHealth>();
            eHealth.ModifyHealth(damageDoneMeleeAttack);
        }
    }
    IEnumerator DestroyGameobject()
    {
        yield return new WaitForSeconds(0.07f);
        Destroy(gameObject);
    }
}