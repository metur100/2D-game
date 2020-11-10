using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHunter : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool knockBackOnHit = false;
    public int damageDoneBullet = -20;
    private float speedOfBullet = 150f;
    private float durationOfStun = 3f;
    void Start()
    {
        rb.velocity = transform.right * speedOfBullet;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
                                        //+++++++KNOCKBACK SCRIPT+++++++///
        // If the player_tag ist Knight and if it's faceing an enemy from left to right, than knock him back -15 on x and 10 on y axes
        if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-450, 15);
            knockBackOnHit = true;
        }// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
        if (other.tag == "Player_Knight" && GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(450, -15);
            knockBackOnHit = true;
        }
        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(damageDoneBullet);
        }
        // If the player_tag ist Knight and if it's faceing an enemy from left to right, than knock him back -15 on x and 10 on y axes
        if (other.tag == "Player_Ninja" && GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-450, 15);
            knockBackOnHit = true;
        }// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
        if (other.tag == "Player_Ninja" && GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(450, -15);
            knockBackOnHit = true;
        }
        if (other.gameObject.tag == "Player_Ninja")
        {
            HealthNinja eHealth = other.gameObject.GetComponent<HealthNinja>();
            eHealth.ModifyHealth(damageDoneBullet);
        }

        if (other.tag == "Player_HolyKnight" && GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-450, 15);
            knockBackOnHit = true;
        }// If the player_tag ist Knight and if it's faceing an enemy from right to left, than knock him back 15 on x and 10 on y axes
        if (other.tag == "Player_HolyKnight" && GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(450, -15);
            knockBackOnHit = true;
        }
        if (other.gameObject.tag == "Player_HolyKnight")
        {
            HealthHolyKnight eHealth = other.gameObject.GetComponent<HealthHolyKnight>();
            eHealth.ModifyHealth(damageDoneBullet);
        }

        Destroy(gameObject);
    }
    //public void CoroutineNoDamageFromArrowHunter()
    //{
    //    StartCoroutine(GetNoDamageFromArrowHunter());
    //}
    //IEnumerator GetNoDamageFromArrowHunter()
    //{
    //    damageDoneBullet = damgeDoneWhenStuned;
    //    yield return new WaitForSeconds(durationOfStun);
    //    damageDoneBullet = damageDoneBulletMax;
    //}
}
