using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarNjinja : MonoBehaviour
{
    [SerializeField]
    private Image Bar;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    private HealthNjinja healthNjinja;

    private void Awake()
    {
        GetComponentInParent<HealthNjinja>().OnHealthPctChanged += HandleHealthChanged;
    }
    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }
    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = Bar.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            Bar.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        Bar.fillAmount = pct;
    }
}
