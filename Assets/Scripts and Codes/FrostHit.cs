using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostHit : MonoBehaviour
{
    float maxS = 40f;
    float slowSpeed = 20f;
    public Rigidbody2D rb;
    //public bool knockBack = false;
    int damage = -5;
    int timeOfReducedSpeed = 2;


    void Start()
    {
        rb.velocity = transform.right * slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Njinja")
        {
           HealthNjinja eHealth = other.gameObject.GetComponent<HealthNjinja>();
           eHealth.ModifyHealth(damage);

            PlayerMovementNjinja reduceMoveSpeed = other.gameObject.GetComponent<PlayerMovementNjinja>();
           reduceMoveSpeed.runSpeed = slowSpeed;

            Destroy(gameObject);
        }

      //  PlayerMovementKnight maxSpeed = other.gameObject.GetComponent<PlayerMovementKnight>();
      //  maxSpeed.runSpeed = maxS;
      //  HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();

       // if (other.gameObject.tag == "Player_Knight")
      //  {
       //     eHealth.ModifyHealth(damage);
       //     StartCoroutine(speedTime());

        //    Destroy(gameObject);
       // }
       // IEnumerator speedTime()
       // {
        //    yield return new WaitForSeconds(timeOfReducedSpeed);
        //    revertSpeed();
      //  }
       // void revertSpeed()
       // {
       //     maxSpeed.runSpeed = slowSpeed;
       // }
    }
}
