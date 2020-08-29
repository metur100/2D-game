using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNinja : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject gameOverUI;
    public Rigidbody2D rb;
    public float normalMovementSpeed = 70f;
    private float slowedMovementSpeed = 20f;
    private float maxMovementSpeed = 70f;
    private float horizontalMove = 0f;
    private float slowOverTimeDuration = 1f;
    private bool jump = false;
    private bool crouch = false;
    private bool grounded;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * normalMovementSpeed;
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
        if (grounded && GetComponent<FireBall>().knockBackOnHit == false)
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

        if (rb.position.y < -6f)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void CoroutineNinja()
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
