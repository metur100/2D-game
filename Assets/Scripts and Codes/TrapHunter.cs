using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHunter : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerMovementNinja mSpeedNinja;
    private PlayerMovementKnight mSpeedKnight;
    private float speedOfTrap = 30f;
    void Start()
    {
        rb.velocity = transform.right * speedOfTrap;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight")
        {
            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineMoveIfTrapKnight();

            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.tag == "Player_Ninja")
            {
                mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
                mSpeedNinja.CoroutineMoveIfTrapNinja();

                Destroy(gameObject);
            }
        }
    }
}
