using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMoveAdvanturer : MonoBehaviour
{
    public Image dashing;
    public Animator animator;
    private Rigidbody2D rb;
    private float dashSpeed = 200f;
    private float dashTime;
    private float startDashTime = 0.5f;
    private int direction;
    private bool isDashing = false;
    private float dashCooldown = 3f;
    private bool isDashCooldown = false;
    //public GameObject dashEffect;

    //public PlayerKnightPosition pos;

    void Start()
    {
        dashing.fillAmount = 0;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && isDashCooldown == false)
            {
                //GameObject Player = Instantiate(dashEffect, transform.position, Quaternion.identity);
                //Player.GetComponent<Rigidbody2D>().AddForce(Player.transform.forward * dashSpeed);
                isDashing = true;
                isDashCooldown = true;
                dashing.fillAmount = 1;
                direction = 1;
                
                FindObjectOfType<AudioManager>().Play("Dash");
            }
            else if (Input.GetKeyDown(KeyCode.E) && isDashCooldown == false)
            {
                //Instantiate(dashEffect, transform.position, Quaternion.identity);
                isDashing = true;
                isDashCooldown = true;
                dashing.fillAmount = 1;
                direction = 2;

                FindObjectOfType<AudioManager>().Play("Dash");
            }
            if (isDashCooldown)
            {
                dashing.fillAmount -= 1 / dashCooldown * Time.deltaTime;
                if (dashing.fillAmount <= 0)
                {
                    dashing.fillAmount = 0;
                    isDashCooldown = false;
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