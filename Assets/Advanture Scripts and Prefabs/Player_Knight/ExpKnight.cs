using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpKnight : MonoBehaviour
{
    [SerializeField]
    private int maxExp = 100;
    public event Action<float> OnExpPctChanged = delegate { };
    public GameObject levelReached;
    [SerializeField]
    public int currentExp;
    public GameObject hideExpBar;
    public HealthKnightAdvanturer maxH;
    private void Start()
    {
        if (currentExp == 0)
        {
            hideExpBar.SetActive(false);
        }
    }
    public void ModifyExp(int amount)
    {
        if (currentExp < maxExp)
        {
            hideExpBar.SetActive(true);
            currentExp += amount;
        }
        if (currentExp >= maxExp)
        {
            currentExp = 0;
            levelReached.SetActive(true);
            maxExp += 50;
            maxH.maxHealth += 50;
            StartCoroutine(DisableText());
        }
        float currentExpPct = (float)currentExp / (float)maxExp;
        OnExpPctChanged(currentExpPct);
    }
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2f);
        levelReached.SetActive(false);
    }
}
