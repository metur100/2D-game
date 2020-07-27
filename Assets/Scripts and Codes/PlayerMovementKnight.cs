using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKnight : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float runSpeed = 70f;
    float slowSpeed = 20f;
    float maxSpeed = 70f;
    float horizontalMove = 0f;
    float slowOverTime = 2f;
    bool jump = false;
    bool crouch = false;
    public bool grounded;
    public Rigidbody2D rb;
    public GameObject gameOverUI;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
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
        StartCoroutine(speedTimeKnight());
    }
    IEnumerator speedTimeKnight()
    {
        runSpeed = slowSpeed;
        yield return new WaitForSeconds(slowOverTime);
        runSpeed = maxSpeed;
    }
}