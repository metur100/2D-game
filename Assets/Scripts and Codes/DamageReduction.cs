using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReduction : MonoBehaviour
{
    public Image damageRed;
    public FrostBall frostBallDamage = new FrostBall();
    public FireBall fireBallDamage = new FireBall();
    public BulletHunter bulletHunterDamage = new BulletHunter();
    //public MeleeAtackHolyKnight meleeAttackDamage = new MeleeAtackHolyKnight();
    //public MeleeAtackHolyKnightNum meleeAttackDamageNum = new MeleeAtackHolyKnightNum();
    public int damageReductionFrostB = 0;
    public int damageReductionFireB = 0;
    public int damageReductionBulletHunt = 0;
    //public int damageReductionMeleeAttackHolyKnight = 0;
    //public int damageReductionMeleeAttackHolyKnightNum = 0;
    public int normalFrostBDmg = -20;
    public int normalFireBDmg = -50;
    public int normalBulletDamage = -10;
    //public int normalMeleeAttackDamageHolyKnight = -20;
    //public int normalMeleeAttackDamageHolyKnightNum = -20;
    private float dmgReductionDuration = 1f;
    private bool isCooldownDmgRed = false;
    private float DmgRedCooldown = 1f;
    // Start is called before the first frame update
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
            //FindObjectOfType<AudioManager>().Play("");
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
        frostBallDamage.damageDoneFrostB = damageReductionFrostB;
        fireBallDamage.damageDoneFireB = damageReductionFireB;
        bulletHunterDamage.damageDoneBullet = damageReductionBulletHunt;
       // meleeAttackDamage.normalMeleeDamage = damageReductionMeleeAttackHolyKnight;
        //meleeAttackDamageNum.normalMeleeDamage = damageReductionMeleeAttackHolyKnightNum;
        yield return new WaitForSeconds(dmgReductionDuration);
        frostBallDamage.damageDoneFrostB = normalFrostBDmg;
        fireBallDamage.damageDoneFireB = normalFireBDmg;
        bulletHunterDamage.damageDoneBullet = normalBulletDamage;
        //meleeAttackDamage.normalMeleeDamage = normalMeleeAttackDamageHolyKnight;
       // meleeAttackDamageNum.normalMeleeDamage = normalMeleeAttackDamageHolyKnightNum;
    }
}
