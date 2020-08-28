﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNinja : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 200;
    public int currentHealth;
    public event Action<float> OnHealthPctChanged = delegate { };
    public GameObject gameOverUI;
    public Animator animator;
    private float delay = 1f;
    private bool isDead = false;
    
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0)
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
            FindObjectOfType<AudioManager>().Play("DeathNjinja");
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            gameOverUI.SetActive(true);

        }

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        FindObjectOfType<AudioManager>().Play("Hurt");
        animator.SetTrigger("isHurt");
    }
}
