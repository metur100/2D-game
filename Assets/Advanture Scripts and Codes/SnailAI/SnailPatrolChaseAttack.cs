using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailPatrolChaseAttack : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float shootingRange;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bulletParent;
    float fireRate = 1f;
    private float nextFireTime;
    [SerializeField]
    Rigidbody2D rb2d;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    private bool isWalking = true;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (distToPlayer < agroRange && distToPlayer > shootingRange && groundInfo.collider == true)
        {
           isWalking = true;
           animator.SetBool("IsWalking", isWalking);
           ChasePlayer();
        }
        else if (distToPlayer <= shootingRange && nextFireTime < Time.time)
        {
            animator.SetTrigger("IsAttacking");
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
            StartShooting();
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
            StopChasingPlayer();
        }
    }
    private void StopChasingPlayer()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.up, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                isWalking = true;
                animator.SetBool("IsWalking", isWalking);
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                isWalking = true;
                animator.SetBool("IsWalking", isWalking);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(20, 20);
        }
        else //if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-20, 20);
        }
    }
    private void StartShooting()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
    }
}
