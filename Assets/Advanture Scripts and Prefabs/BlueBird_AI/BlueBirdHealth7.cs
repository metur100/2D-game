using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlueBirdHealth7 : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 200;
    public event Action<float> OnHealthPctChanged = delegate { };
    public Animator animator;
    [SerializeField]
    private int currentHealth;
    //private float delay = 1f;
    public GameObject deathEffect;
    public GameObject dropItem;
    public Button activateDeathCount;
    private bool isDead;
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
        if (currentHealth <= 0 && !isDead)
        {
            //FindObjectOfType<AudioManager>().Play("Death");
            isDead = true;
            activateDeathCount.onClick.Invoke();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(dropItem, transform.position, Quaternion.identity);
            Destroy(gameObject/*this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length*/);

        }
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        //FindObjectOfType<AudioManager>().Play("Hurt");
        animator.SetTrigger("IsHurt");
    }
}
