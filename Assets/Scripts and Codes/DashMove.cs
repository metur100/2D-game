using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Animator animator;
    private bool isDashing = false;
    public Image dashing;
    public float cooldown = 2f;
    bool isCooldown = false;

    void Start()
    {
        dashing.fillAmount = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         if (direction == 0)
         {
             if (Input.GetKeyDown(KeyCode.Q) && isCooldown == false)
             {
                isCooldown = true;
                dashing.fillAmount = 1;
                isDashing = true;
                direction = 1;
                FindObjectOfType<AudioManager>().Play("Dash");
             }
             else if (Input.GetKeyDown(KeyCode.E) && isCooldown == false)
             {
                isDashing = true;
                isCooldown = true;
                dashing.fillAmount = 1;
                direction = 2;
                FindObjectOfType<AudioManager>().Play("Dash");
             }
            if (isCooldown)
            {
                dashing.fillAmount -= 1 / cooldown * Time.deltaTime;
                if (dashing.fillAmount <= 0)
                {
                    dashing.fillAmount = 0;
                    isCooldown = false;
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