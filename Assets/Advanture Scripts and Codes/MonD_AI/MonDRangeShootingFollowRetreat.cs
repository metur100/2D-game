using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonDRangeShootingFollowRetreat : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private bool isWalking;
    private bool isShooting;

    public Rigidbody2D rb;

    public GameObject projectile;
    public GameObject shootingPoint;
    public Animator animator;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player_Knight_Advanturer").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            //walking
            isWalking = true;
            isShooting = false;
            animator.SetBool("IsShooting", isShooting);
            animator.SetBool("walk", isWalking);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            //shoting
            transform.position = this.transform.position;
            isWalking = false;
            animator.SetBool("walk", isWalking);
            isShooting = true;
            animator.SetBool("IsShooting", isShooting);
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            //retreating
            isShooting = false;
            animator.SetBool("IsShooting", isShooting);
            isWalking = true;
            animator.SetBool("walk", isWalking);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            isShooting = true;
            animator.SetBool("IsShooting", isShooting);
            Instantiate(projectile, shootingPoint.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
