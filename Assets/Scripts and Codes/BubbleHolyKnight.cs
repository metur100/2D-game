using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BubbleHolyKnight : MonoBehaviour
{
    public Image invulnerable;
    public Animator anim;
    private bool isCooldownInvuln = false;
    private float invulnerabelCooldown = 9f;
    private bool isBubble = false;

    // Start is called before the first frame update
    void Start()
    {
        invulnerable.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isCooldownInvuln == false)
        {
            isCooldownInvuln = true;
            invulnerable.fillAmount = 1;
            StartCoroutine(GetInvulnerable());
            isBubble = true;
            anim.SetBool("isBubble", isBubble);
            isBubble = false;
            //FindObjectOfType<AudioManager>().Play("");
        }
        if (isCooldownInvuln)
        {
            invulnerable.fillAmount -= 1 / invulnerabelCooldown * Time.deltaTime;
            if (invulnerable.fillAmount <= 0)
            {
                invulnerable.fillAmount = 0;
                isCooldownInvuln = false;
            }
        }
    }
    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(19, 17, true);
        Physics2D.IgnoreLayerCollision(19, 14, true);
        Physics2D.IgnoreLayerCollision(19, 18, true);
        Physics2D.IgnoreLayerCollision(19, 10, true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(19, 17, false);
        Physics2D.IgnoreLayerCollision(19, 14, false);
        Physics2D.IgnoreLayerCollision(19, 18, false);
        Physics2D.IgnoreLayerCollision(19, 10, true);
    }
}
