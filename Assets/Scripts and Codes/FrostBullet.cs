using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    int damage = -5;
    int speedOfFrostBullet = 50;
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
            healthNinja.ModifyHealth(damage);

            mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
            mSpeedNinja.CoroutineNinja();
        }

        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight healthKnight = other.gameObject.GetComponent<HealthKnight>();
            healthKnight.ModifyHealth(damage);

            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineKnight();
        }
        Destroy(gameObject);
    }
}   