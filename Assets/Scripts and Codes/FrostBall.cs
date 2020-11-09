using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damageDoneFrostB = -20;  
    private int speedOfFrostBullet = 100;
    private PlayerMovementHunter mSpeedHunter;
    private PlayerMovementKnight mSpeedKnight;
    void Start()
    {
        rb.velocity = transform.right * speedOfFrostBullet;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Hunter")
        {
            HealthHunter healthNinja = other.gameObject.GetComponent<HealthHunter>();
            healthNinja.ModifyHealth(damageDoneFrostB);

            mSpeedHunter = other.gameObject.GetComponent<PlayerMovementHunter>();
            mSpeedHunter.CoroutineHunterSlowOverTimeFrost();
        }

        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight healthKnight = other.gameObject.GetComponent<HealthKnight>();
            healthKnight.ModifyHealth(damageDoneFrostB);

            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineKnightSlowOverTimeFrost();
        }
        Destroy(gameObject);
    }
}   