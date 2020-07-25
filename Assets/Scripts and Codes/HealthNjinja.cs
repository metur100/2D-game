using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNjinja : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;
    bool isDead = false;
    public Animator animator;
    float delay = 1f;
    public event Action <float> OnHealthPctChanged = delegate { };
    public GameObject gameOverUI;

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
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            gameOverUI.SetActive(true);
        }

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        animator.SetTrigger("isHurt");
    }
}
