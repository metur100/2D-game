using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaleAttack : MonoBehaviour
{
    private bool Attacking = false;

    private float attackTimer = 0.0f;
    private float attackCD = 0.01f;

    public Image maleAttack;
    public float cooldown = 2f;
    bool isCooldown = false;

    public Collider2D MaleTrigger;
    public Animator animator;

    void Start()
    {
        maleAttack.fillAmount = 0;
    }
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        MaleTrigger.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("MaleAttack") && !Attacking && isCooldown == false)
        {
            isCooldown = true;
            Attacking = true;
            maleAttack.fillAmount = 1;
            FindObjectOfType<AudioManager>().Play("SwordAttack");
            attackTimer = attackCD;
            MaleTrigger.enabled = true;
        }
        if (isCooldown)
        {
            maleAttack.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (maleAttack.fillAmount <= 0)
            {
                maleAttack.fillAmount = 0;
                isCooldown = false;
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
