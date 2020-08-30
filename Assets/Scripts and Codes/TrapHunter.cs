using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHunter : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damageDoneTrap = -5;
    private PlayerMovementNinja mSpeedNinja;
    private PlayerMovementKnight mSpeedKnight;
    public MeleeAttack disableMeleeAttack;
    private float speedOfTrap = 30f;
    void Start()
    {
        rb.velocity = transform.right * speedOfTrap;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight")
        {
            //disableMeleeAttack.isMaleeAttacking = false;
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(damageDoneTrap);

            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineMoveIfTrapKnight();

            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.tag == "Player_Ninja")
            {
                HealthNinja eHealth = other.gameObject.GetComponent<HealthNinja>();
                eHealth.ModifyHealth(damageDoneTrap);

                mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
                mSpeedNinja.CoroutineMoveIfTrapNinja();

                Destroy(gameObject);
            }
        }
    }
}
