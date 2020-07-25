using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private float cooldownTime = 1f;
    private float nextFireTime = 0f;

    public Animator animator;

    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    nextFireTime = Time.time + cooldownTime;
                    isDashing = true;
                    direction = 1;
                    FindObjectOfType<AudioManager>().Play("Dash");
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    nextFireTime = Time.time + cooldownTime;
                    isDashing = true;
                    direction = 2;
                    FindObjectOfType<AudioManager>().Play("Dash");
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    isDashing = false;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    isDashing = false;
                }
            }
        }
       animator.SetBool("isDashing", isDashing);
    }
}