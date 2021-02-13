using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class GreenPigHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 200;
    public event Action<float> OnHealthPctChanged = delegate { };
    public Animator animator;
    public GreenPigChaseAndAttack moveSpeed;
    [SerializeField]
    private int currentHealth;
    public GameObject deathEffect;
    public GameObject dropItem;
    public GameObject destroyWallAndEnemies;
    SpriteRenderer spriteColor;
    void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>();
    }
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
        if (currentHealth <= 50)
        {
            moveSpeed.speed = 100;
            spriteColor.color = new Color(255, 0, 0, 255);
        }
        if (currentHealth < 0)
        {
            //isDead = true;
            //animator.SetBool("isDead", isDead);
            //FindObjectOfType<AudioManager>().Play("Death");
            CameraShaker.Instance.ShakeOnce(0.4f, 10f, 2f, 2f);
            StartCoroutine(WaitTime());
            //gameOverUI.SetActive(true);
        }
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        //FindObjectOfType<AudioManager>().Play("Hurt");
        animator.SetTrigger("IsHurt");
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(dropItem, transform.position, Quaternion.identity);
        Destroy(destroyWallAndEnemies);
        Destroy(gameObject);
    }
}
