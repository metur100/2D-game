using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleAttack : MonoBehaviour
{
    private bool Attacking = false;

    private float attackTimer = 0.0f;
    private float attackCD = 0.01f;

    private float cooldownTime = 2;
    private float nextFireTime = 0;

    public Collider2D MaleTrigger;

    public Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        MaleTrigger.enabled = false;
    }
    
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetButtonDown("MaleAttack") && !Attacking)
            {
                nextFireTime = Time.time + cooldownTime;
                Attacking = true;
                attackTimer = attackCD;

                MaleTrigger.enabled = true;
            }
        }

        if (Attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                Attacking = false;
                MaleTrigger.enabled = false;
            }
        }
        animator.SetBool("IsAttacking", Attacking);
    }
}
