using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingStunHolyKnightNum : MonoBehaviour
{
    public Transform firePointStun;
    public GameObject stunPrefab;
    public Animator animator;
    public Image shootingStun;
    private float cooldownStun = 2f;
    private bool iscooldownStun = false;

    void Start()
    {
        shootingStun.fillAmount = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("StunHolyKnight2") && iscooldownStun == false)
        {
            iscooldownStun = true;
            shootingStun.fillAmount = 1;
            ShootBullet();
            animator.SetTrigger("Throw");
        }
        if (iscooldownStun)
        {
            shootingStun.fillAmount -= 1 / cooldownStun * Time.deltaTime;
            if (shootingStun.fillAmount <= 0)
            {
                shootingStun.fillAmount = 0;
                iscooldownStun = false;
            }
        }
    }
    void ShootBullet()
    {
        Instantiate(stunPrefab, firePointStun.position, firePointStun.rotation);
    }
}
