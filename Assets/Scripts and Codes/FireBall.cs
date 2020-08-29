using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool knockBackOnHit = false;
    public int damageDoneFireB = -50;
    private float speedOfFireBall = 50f;
    void Start()
    {
        rb.velocity = transform.right * speedOfFireBall;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
                                                //+++++++KNOCKBACK SCRIPT+++++++///
        // If the player_tag ist Knight and if it's faceing an enemy from left to right, than knock him back -15 on x and 10 on y axes
        if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-40, 15);
            knockBackOnHit = true;
        }// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
        else if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(40, -15);
            knockBackOnHit = true;
        }
        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(damageDoneFireB);
        }
        else
        {
            // If the player_tag ist Knight and if it's faceing an enemy from left to right, than knock him back -15 on x and 10 on y axes
            if (other.tag == "Player_Hunter" && GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(-40, 15);
                knockBackOnHit = true;
            }// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
            else if (other.tag == "Player_Hunter" && GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(40, -15);
                knockBackOnHit = true;
            }
            if (other.gameObject.tag == "Player_Hunter")
            {
                HealthHunter eHealth = other.gameObject.GetComponent<HealthHunter>();
                eHealth.ModifyHealth(damageDoneFireB);
            }
        }
        Destroy(gameObject);
    }
}
