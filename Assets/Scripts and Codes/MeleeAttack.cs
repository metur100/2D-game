using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    private bool Attacking = false;
    private float attackTimer = 0.0f;
    private float attackCD = 0.01f;
    public Image meleeAttack;
    public float cooldown = 1f;
    bool isCooldown = false;
    public Collider2D meleeTrigger;
    public Animator animator;
    public MaleTrigger dmg;
    float damageTimeIncreased = 6f;
    int enragedMeleeDamage = -40;
    int normalMeleeDamage = -20;

    void Start()
    {
        meleeAttack.fillAmount = 0;
    }
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        meleeTrigger.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(IncreasedDamage());
        }
        if (Input.GetButtonDown("meleeAttack") && !Attacking && isCooldown == false)
        {
            isCooldown = true;
            Attacking = true;
            meleeAttack.fillAmount = 1;
            FindObjectOfType<AudioManager>().Play("SwordAttack");
            attackTimer = attackCD;
            meleeTrigger.enabled = true;
        }
        if (isCooldown)
        {
            meleeAttack.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (meleeAttack.fillAmount <= 0)
            {
                meleeAttack.fillAmount = 0;
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
                meleeTrigger.enabled = false;
            }
        }
        animator.SetBool("IsAttacking", Attacking);
    }
    IEnumerator IncreasedDamage()
    {
        dmg.normalMeleeDmg = enragedMeleeDamage;
        yield return new WaitForSeconds(damageTimeIncreased);
        dmg.normalMeleeDmg = normalMeleeDamage;
    }
}
