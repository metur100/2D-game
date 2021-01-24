using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeHealthPatrol : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 200;
    public event Action<float> OnHealthPctChanged = delegate { };
    //public GameObject gameOverUI;
    public Animator animator;
    [SerializeField]
    private int currentHealth;
    private bool isDead = false;
    //private float delay = 1f;
    public GameObject deathEffect;

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
            //isDead = true;
            //animator.SetBool("isDead", isDead);
            //FindObjectOfType<AudioManager>().Play("Death");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject/*this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length*/);

        }
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        //FindObjectOfType<AudioManager>().Play("Hurt");
        animator.SetTrigger("isHurt");
    }
}
