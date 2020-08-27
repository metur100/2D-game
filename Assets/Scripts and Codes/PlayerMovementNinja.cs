using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNinja : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float runSpeed = 70f;
    float slowSpeed = 20f;
    float maxSpeed = 70f;
    float horizontalMove = 0f;
    float slowOverTime = 1f;
    bool jump = false;
    bool crouch = false;
    public bool grounded;
    public Rigidbody2D rb;
    public GameObject gameOverUI;
// public float blinkDistance;
// float blinkTimer;
// public float blinkTime = 1f;
// bool facingRight;
// bool canBlink = true;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
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
 //    if (Input.GetKeyDown(KeyCode.I) && canBlink)
 //    {
 //       // PlaySound(0);
 //        animator.SetBool("isBlinking", true);
 //        canBlink = false;
 //    }
 //    else
 //        animator.SetBool("isBlinking", false);
 //
 //    if (!canBlink)
 //    {
 //        blinkTimer += Time.deltaTime;
 //    }
 //    if (blinkTimer > blinkTime)
 //    {
 //        canBlink = true;
 //        blinkTimer = 0;
 //    }
 //    if (transform.right.x == 1)
 //    {
 //        facingRight = true;
 //    }
 //    else
 //    {
 //        facingRight = false;
 //    }
    }
 //void Blink()
 //{
 //    Vector3 blink;
 //    if (facingRight)
 //        blink = new Vector3(blinkDistance, 0, 0);
 //    else
 //        blink = new Vector3(-blinkDistance, 0, 0);
 //
 //    transform.position += blink;
 //}
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
