﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKnight : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject gameOverUI;
    private float normalMovementSpeed = 70f;
    private float slowedMovementSpeed = 20f;
    private float maxMovementSpeed = 70f;
    private float horizontalMove = 0f;
    private float slowOverTimeDuration = 2f;
    private bool jump = false;
    private bool crouch = false;
    private bool grounded;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * normalMovementSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if (Input.GetButtonDown("Jump") && Input.GetButtonDown("meleeAttack"))
        {
            jump = true;
            animator.SetBool("isJumpAttack", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
           crouch = true;
        }

       else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        if (rb.position.y < -6f)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void CoroutineKnight()
    {
        StartCoroutine(SlowOverTimeOnHitWithFrostBullet());
    }
    IEnumerator SlowOverTimeOnHitWithFrostBullet()
    {
        normalMovementSpeed = slowedMovementSpeed;
        yield return new WaitForSeconds(slowOverTimeDuration);
        normalMovementSpeed = maxMovementSpeed;
    }
}