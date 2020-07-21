using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNjinja : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float runSpeed = 40f;
    float slowSpeed = 20f;
    float maxSpeed = 40f;
    float horizontalMove = 0f;
    float slowOverTime = 1f;

    bool jump = false;
    bool crouch = false;

    public bool grounded;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch2"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch2"))
        {
            crouch = false;
        }
        if (grounded && GetComponent<FireBullet>().knockBack == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
    }
    public void CoroutineNinja()
    {
        StartCoroutine(speedTimeNinja());
    }
    IEnumerator speedTimeNinja()
    {
        runSpeed = slowSpeed;
        yield return new WaitForSeconds(slowOverTime);
        runSpeed = maxSpeed;
    }
}
