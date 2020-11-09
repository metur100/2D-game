﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBackwardHunterNum : MonoBehaviour
{
    public Image dashingBackward;
    ///public Animator animator;
    private Rigidbody2D rb;
    private float dashSpeed = 100f;
    private float dashTime;
    private float startDashTime = 0.5f;
    private int direction;
    private bool isDashingBackward = false;
    private float dashingBackwardCooldown = 3f;
    private bool isDashingBackwardCooldown = false;

    void Start()
    {
        dashingBackward.fillAmount = 0;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Keypad7) && isDashingBackwardCooldown == false)
            {
                isDashingBackwardCooldown = true;
                dashingBackward.fillAmount = 1;
                isDashingBackward = true;
                direction = 1;
                FindObjectOfType<AudioManager>().Play("Dash");
            }
            else if (Input.GetKeyDown(KeyCode.Keypad9) && isDashingBackwardCooldown == false)
            {
                isDashingBackward = true;
                isDashingBackwardCooldown = true;
                dashingBackward.fillAmount = 1;
                direction = 2;
                FindObjectOfType<AudioManager>().Play("Dash");
            }
            if (isDashingBackwardCooldown)
            {
                dashingBackward.fillAmount -= 1 / dashingBackwardCooldown * Time.deltaTime;
                if (dashingBackward.fillAmount <= 0)
                {
                    dashingBackward.fillAmount = 0;
                    isDashingBackwardCooldown = false;
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
                    rb.velocity = Vector2.right * dashSpeed;
                    isDashingBackward = false;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    isDashingBackward = false;
                }
            }
        }
        ///animator.SetBool("isDashingBackward", isDashingBackward);
    }
}
