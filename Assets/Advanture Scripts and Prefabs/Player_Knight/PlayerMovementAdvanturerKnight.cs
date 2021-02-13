using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAdvanturerKnight : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject gameOverUIAdvanture;
    public float normalMovementSpeed = 250f;
    private float horizontalMove = 0f;
    private bool crouch = false;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isJumping;
    public float jumpForce;

    private float jumpTimeCounter;
    public float jumpTime;

    public ParticleSystem dust;
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * normalMovementSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("takeOf");
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            CreateDust();
        }

        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            CreateDust();
        }
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //    animator.SetBool("IsJumping", true);
        //    FindObjectOfType<AudioManager>().Play("Jump");
        //}
        //if (Input.GetButtonDown("Jump") && Input.GetButtonDown("meleeAttack"))
        //{
        //    jump = true;
        //    animator.SetBool("isJumpAttack", true);
        //}
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    //public void OnLanding()
    //{
    //    animator.SetBool("IsJumping", false);
    //}
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, isJumping);

        if (rb.position.y < -800f)
        {
            gameOverUIAdvanture.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Moving_Platform"))
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Moving_Platform"))
            this.transform.parent = null;
    }
    void CreateDust()
    {
        dust.Play();
    }
}