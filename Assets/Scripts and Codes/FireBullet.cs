using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public bool knockBack = false;
    int damage = -10;
    

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
                                                //+++++++KNOCKBACK SCRIPT+++++++///
        //// If the player_tag ist Knight and if it's faceing an enemy from left to right, than knock him back -15 on x and 10 on y axes
        //if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x < 0)
        //{
        //    other.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 10);
        //    knockBack = true;
        //}// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
        //else if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x > 0)
        //{
        //    other.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 10);
        //    knockBack = true;
        //}//-||- look Knight, its same
        //if (other.tag == "Player_Njinja" && GetComponent<Rigidbody2D>().velocity.x < 0)
        //{
        //    other.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 10);
        //    knockBack = true;
        //}//-||- look Knight, its same
        //else if (other.tag == "Player_Njinja" && GetComponent<Rigidbody2D>().velocity.x > 0)
        //{
        //    other.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 10);
        //    knockBack = true;
        //}

        if (other.gameObject.tag == "Player_Njinja")
        {
            HealthNjinja eHealth = other.gameObject.GetComponent<HealthNjinja>();
            eHealth.ModifyHealth(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(damage);
            Destroy(gameObject);
        }
    }
}
