using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Image blinking;
    public float blinkDistance;
    float blinkTimer;
    public float blinkTime = 1f;
    bool facingRight;
    bool canBlink = true;

    void Start()
    {
        blinking.fillAmount = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && canBlink)
        {
            // PlaySound(0);
            animator.SetBool("isBlinking", true);
            canBlink = false;
        }
        else
            animator.SetBool("isBlinking", false);

        if (!canBlink)
        {
            blinkTimer += Time.deltaTime;
        }
        if (blinkTimer > blinkTime)
        {
            canBlink = true;
            blinkTimer = 0;
        }
        if (transform.right.x == 1)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
    }
        //animator.SetBool("isDashing", isDashing);
}