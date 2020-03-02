using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNjinja : MonoBehaviour
{
    public Transform firePoint2;
    public GameObject bulletPrefab2;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
            animator.SetTrigger("Throw");
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
    }
}
