using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBall : MonoBehaviour
{
    public Rigidbody2D rb;
    private int damageDone = -10;
    private int speedOfFrostBullet = 50;
    private PlayerMovementNinja mSpeedNinja;
    private PlayerMovementKnight mSpeedKnight;
    void Start()
    {
        rb.velocity = transform.right * speedOfFrostBullet;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Ninja")
        {
            HealthNinja healthNinja = other.gameObject.GetComponent<HealthNinja>();
            healthNinja.ModifyHealth(damageDone);

            mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
            mSpeedNinja.CoroutineNinja();
        }

        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight healthKnight = other.gameObject.GetComponent<HealthKnight>();
            healthKnight.ModifyHealth(damageDone);

            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineKnight();
        }
        Destroy(gameObject);
    }
}   