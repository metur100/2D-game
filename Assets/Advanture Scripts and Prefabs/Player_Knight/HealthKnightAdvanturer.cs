using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthKnightAdvanturer : MonoBehaviour
{
    public int maxHealth = 200;
    public event Action<float> OnHealthPctChanged = delegate { };
    public GameObject gameOverUI;
    public Animator animator;
    [SerializeField]
    public int currentHealth;
    Renderer rend;
    Color c;
    public int lifes = 3;
    public RespawnManager respawn;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 21, false);
        Physics2D.IgnoreLayerCollision(11, 22, false);
        Physics2D.IgnoreLayerCollision(11, 23, false);
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        respawn = FindObjectOfType<RespawnManager>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        StartCoroutine(TemporalInvulnerability());
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            lifes--;
            TrackLifes.scoreValue -= 1;
            respawn.RespawnPlayer();
            currentHealth = 200;
            if (lifes <= 0)
            {
                Destroy(gameObject);
                gameOverUI.SetActive(true);
                //animator.SetBool("IsDead", isDead);
                //FindObjectOfType<AudioManager>().Play("Death");
            }
        }
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);    
        FindObjectOfType<AudioManager>().Play("Hurt");
        animator.SetTrigger("IsHurt");
    }
    IEnumerator TemporalInvulnerability()
    {
        Physics2D.IgnoreLayerCollision(11, 21, true);
        Physics2D.IgnoreLayerCollision(11, 22, true);
        Physics2D.IgnoreLayerCollision(11, 23, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(11, 21, false);
        Physics2D.IgnoreLayerCollision(11, 22, false);
        Physics2D.IgnoreLayerCollision(11, 23, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
