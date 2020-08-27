using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    public Collider2D meleeTrigger;
    public Animator animator;
    public MaleTrigger dmg;
    public Image meleeAttack;
    public Image enrage;
    private bool Attacking = false;
    private float attackTimer = 0.0f;
    private float attackCD = 0.01f;
    private float cooldownMaleeAttack = 1f;
    private float cooldownEnrage = 10f;
    private bool isCooldownMaleeAttack = false;
    private bool isCooldownEnrage = false;
    private float enrageDuration = 6f;
    private int enragedMeleeDamage = -40;
    private int normalMeleeDamage = -20;

    void Start()
    {
        meleeAttack.fillAmount = 0;
        enrage.fillAmount = 0;
    }
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        meleeTrigger.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && isCooldownEnrage == false)
        {
            isCooldownEnrage = true;
            enrage.fillAmount = 1;
            StartCoroutine(EnrageDamage());
            //FindObjectOfType<AudioManager>().Play("");
        }
        if (Input.GetButtonDown("meleeAttack") && !Attacking && isCooldownMaleeAttack == false)
        {
            isCooldownMaleeAttack = true;
            Attacking = true;
            meleeAttack.fillAmount = 1;
            FindObjectOfType<AudioManager>().Play("SwordAttack");
            attackTimer = attackCD;
            meleeTrigger.enabled = true;
        }
        if (isCooldownEnrage)
        {
            enrage.fillAmount -= 1 / cooldownEnrage * Time.deltaTime;
            if (enrage.fillAmount <= 0)
            {
                enrage.fillAmount = 0;
                isCooldownEnrage = false;
            }
        }
        if (isCooldownMaleeAttack)
        {
            meleeAttack.fillAmount -= 1 / cooldownMaleeAttack * Time.deltaTime;
            if (meleeAttack.fillAmount <= 0)
            {
                meleeAttack.fillAmount = 0;
                isCooldownMaleeAttack = false;
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
    IEnumerator EnrageDamage()
    {
        dmg.normalMeleeDmg = enragedMeleeDamage;
        yield return new WaitForSeconds(enrageDuration);
        dmg.normalMeleeDmg = normalMeleeDamage;
    }
}
