using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GreenPigWallHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;
    public event Action<float> OnHealthPctChanged = delegate { };
    //public Animator animator;
    [SerializeField]
    public int currentHealth;

    //QuestGoal current;
    private void OnEnable()
    {
        currentHealth = maxHealth;
        //current = GetComponent<QuestGoal>();
    }
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject/*this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length*/);

        }
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        //animator.SetTrigger("IsHurt");
    }
}
