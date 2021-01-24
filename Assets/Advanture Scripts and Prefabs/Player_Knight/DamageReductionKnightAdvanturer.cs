using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReductionKnightAdvanturer : MonoBehaviour
{
    public Image damageRed;
    public Animator animator;
    public SlimAttackPrefab doDamage;
    private int damageReductionSlimAttack = 0;
    private int normalSlimmAttackDmg = -20;
    private float dmgReductionDuration = 1f;
    private bool isCooldownDmgRed = false;
    private float DmgRedCooldown = 2f;
    private bool isBlock = false;
    //Start is called before the first frame update
    void Start()
    {
        damageRed.fillAmount = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isCooldownDmgRed == false)
        {
            isCooldownDmgRed = true;
            damageRed.fillAmount = 1;
            StartCoroutine(DamageReductionDurationFrostB());
            FindObjectOfType<AudioManager>().Play("BlockedKnight");
        }
        if (isCooldownDmgRed)
        {
            damageRed.fillAmount -= 1 / DmgRedCooldown * Time.deltaTime;
            if (damageRed.fillAmount <= 0)
            {
                damageRed.fillAmount = 0;
                isCooldownDmgRed = false;
            }
        }
    }
    IEnumerator DamageReductionDurationFrostB()
    {
        doDamage.damageDone = damageReductionSlimAttack;
        isBlock = true;
        animator.SetBool("IsBlock", isBlock);
        yield return new WaitForSeconds(dmgReductionDuration);
        isBlock = false;
        animator.SetBool("IsBlock", isBlock);
        doDamage.damageDone = normalSlimmAttackDmg;
    }
}
