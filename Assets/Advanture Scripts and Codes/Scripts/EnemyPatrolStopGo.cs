using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolStopGo : MonoBehaviour
{
	public float speed = 10f;
	public bool MoveRight;
	public Animator animator;
	private bool isInvulnerable = false;
	private float ignoreCollisionOverTime = 2f;
	// Use this for initialization
	void Update()
	{
		// Use this for initialization
		if (MoveRight)
		{
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			StartCoroutine(GetInvulnerable());
			transform.localScale = new Vector2(-20, 20);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(20, 20);
		}
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("ShootAtMe"))
		{

			if (MoveRight)
			{
				MoveRight = false;
			}
			else
			{
				MoveRight = true;
			}
		}
	}
	IEnumerator GetInvulnerable()
	{
		Physics2D.IgnoreLayerCollision(21, 11, true);;
		speed = 0f;
		isInvulnerable = true;
		animator.SetBool("IsHiding", isInvulnerable);
		yield return new WaitForSeconds(ignoreCollisionOverTime);
		speed = 10f;
		isInvulnerable = false;
		animator.SetBool("IsHiding", isInvulnerable);
		Physics2D.IgnoreLayerCollision(21, 11, false);

	}
}
