using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;

    public float cooldownTime = 2;
    private float nextFireTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {

            if (Input.GetButtonDown("Fire3"))
            {
                nextFireTime = Time.time + cooldownTime;
                Shoot();
                animator.SetTrigger("Throw");
            }
        }
    }
    void Shoot()
    {
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
