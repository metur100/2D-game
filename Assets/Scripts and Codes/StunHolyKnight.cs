using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunHolyKnight : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerMovementNinja mSpeedNinja;
    private PlayerMovementKnight mSpeedKnight;
    private PlayerMovementHunter mSpeedHunter;
    private PlayerMovementNinjaNum mSpeedNinjaNum;
    private PlayerMovementKnightNum mSpeedKnightNum;
    private PlayerMovementHunterNum mSpeedHunterNum;
    public BulletHunter bulletDealsNoDamage = new BulletHunter();
    public MaleTrigger noDmgMeleeAttack = new MaleTrigger();
    public FrostBall noDmgFrostBall = new FrostBall();
    public FireBall noDmgFireBall = new FireBall();
    private int bulletDealsNoDmg = 0;
    private int maxDamageFromBullet = -20;
    private int frostBallDealsNoDamage = 0;
    private int frostBallMaxDamage = -20;
    private int fireBallDealsNoDamage = 0;
    private int fireBallMaxDamage = -50;
    private int meleeAttackNoDmg = 0;
    private int meleeAttackMaxDmg = -20;
    private float durationOfStun = 3f;
    private float speedOfStun = 150f;
    private float destroyStun = 4f;
    void Start()
    {
        rb.velocity = transform.right * speedOfStun;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight")
        {
            mSpeedKnight = other.gameObject.GetComponent<PlayerMovementKnight>();
            mSpeedKnight.CoroutineMoveIfTrapKnight();
            mSpeedKnightNum = other.gameObject.GetComponent<PlayerMovementKnightNum>();
            mSpeedKnightNum.CoroutineMoveIfTrapKnight();

            StartCoroutine(GetNoDamageFromMeleeAttackKnight());

            Object.Destroy(gameObject, destroyStun);
        }
        if (other.gameObject.tag == "Player_Hunter")
        {
            StartCoroutine(GetNoDamageFromArrowHunter());
            //mSpeedHunter = other.gameObject.GetComponent<PlayerMovementHunter>();
            //mSpeedHunter.CoroutineMoveIfTrapHunter();
            mSpeedHunterNum = other.gameObject.GetComponent<PlayerMovementHunterNum>();
            mSpeedHunterNum.CoroutineMoveIfTrapHunter();

            Object.Destroy(gameObject, destroyStun);
        }

        if (other.gameObject.tag == "Player_Ninja")
        {
            mSpeedNinja = other.gameObject.GetComponent<PlayerMovementNinja>();
            mSpeedNinja.CoroutineMoveIfTrapNinja();
            mSpeedNinjaNum = other.gameObject.GetComponent<PlayerMovementNinjaNum>();
            mSpeedNinjaNum.CoroutineMoveIfTrapNinja();

            StartCoroutine(GetNoDamageFromFrostBall());
            StartCoroutine(GetNoDamageFromFireBall());

            Object.Destroy(gameObject, destroyStun);
        }
    }
    IEnumerator GetNoDamageFromArrowHunter()
    {
        bulletDealsNoDamage.damageDoneBullet = bulletDealsNoDmg;
        yield return new WaitForSeconds(durationOfStun);
        bulletDealsNoDamage.damageDoneBullet = maxDamageFromBullet;
    }
    IEnumerator GetNoDamageFromMeleeAttackKnight()
    {
        noDmgMeleeAttack.normalMeleeDmg = meleeAttackNoDmg;
        yield return new WaitForSeconds(durationOfStun);
        noDmgMeleeAttack.normalMeleeDmg = meleeAttackMaxDmg;
    }
    IEnumerator GetNoDamageFromFrostBall()
    {
        noDmgFrostBall.damageDoneFrostB = frostBallDealsNoDamage;
        yield return new WaitForSeconds(durationOfStun);
        noDmgFrostBall.damageDoneFrostB = frostBallMaxDamage;
    }
    IEnumerator GetNoDamageFromFireBall()
    {
        noDmgFireBall.damageDoneFireB = fireBallDealsNoDamage;
        yield return new WaitForSeconds(durationOfStun);
        noDmgFireBall.damageDoneFireB = fireBallMaxDamage;
    }
}
