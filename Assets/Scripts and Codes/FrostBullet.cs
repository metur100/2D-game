using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    int damage = -20;
    int speedOfFrostBullet = 30;

    public PlayerMovementNjinja mSpeedNinja;
    public PlayerMovementKnight mSpeedKnight;

    void Start()
    {
        rb.velocity = transform.right * speedOfFrostBullet;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Njinja")
        {
            HealthNjinja healthNjinja = other.gameObject.GetComponent<HealthNjinja>();
            healthNjinja.ModifyHealth(damage);

            mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNjinja>();
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