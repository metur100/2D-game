using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunHolyKnight : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerMovementNinja mSpeedNinja;
    private PlayerMovementKnight mSpeedKnight;
    private PlayerMovementHunter mSpeedHunter;
    private float speedOfStun = 30f;
    void Start()
    {
        rb.velocity = transform.right * speedOfStun;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight")
        {
            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineMoveIfTrapKnight();

            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player_Hunter")
        {
            mSpeedHunter = other.gameObject.GetComponent<PlayerMovementHunter>();
            mSpeedHunter.CoroutineMoveIfTrapHunter();

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player_Ninja")
        {
            mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
            mSpeedNinja.CoroutineMoveIfTrapNinja();

            Destroy(gameObject);
        }
    }
}
