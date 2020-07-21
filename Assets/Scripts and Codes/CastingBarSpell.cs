using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastingBarSpell : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Animator animator;

    public Transform firePoint2;
    public GameObject bulletPrefab2;

    public float cooldownTime = 2;
    private float nextFireTime = 0;

    private Vector3 starPos;
    private Vector3 endPos;

    private Image castImage;

    private RectTransform castTransoform;

    private bool casting;

    public CanvasGroup canvasGroup;
    public float fadeSpeed;

    private Spell frostBall = new Spell("Frost Ball", 2f, Color.blue);
    private Spell fireBall = new Spell("Fire Ball", 2f, Color.red);
    // Start is called before the first frame update
    void Start()
    {
        casting = false;
        castTransoform = GetComponent<RectTransform>();
        castImage = GetComponent<Image>();

        endPos = castTransoform.position;
        starPos = new Vector3(castTransoform.position.x - castTransoform.rect.width, castTransoform.position.y, castTransoform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                nextFireTime = Time.time + cooldownTime;
                StartCoroutine(CastSpell(frostBall));
                StartCoroutine(ShootFrost());
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                nextFireTime = Time.time + cooldownTime;
                StartCoroutine(CastSpell(fireBall));
                StartCoroutine(ShootFire());
            }
        }
    }

    private IEnumerator FadeOut()
    {
        StopCoroutine("FadeIn");
        while (canvasGroup.alpha > 0f)
        {
            float newValue = fadeSpeed * Time.deltaTime;
            if((canvasGroup.alpha - newValue) > 0f)
            {
                canvasGroup.alpha -= newValue;
            }
            else
            {
                canvasGroup.alpha = 0;
            }
            yield return null;
        }
    }
    private IEnumerator FadeIn()
    {
        StopCoroutine("FadeOut");
        while (canvasGroup.alpha < 1f)
        {
            float newValue = fadeSpeed * Time.deltaTime;
            if ((canvasGroup.alpha + newValue) < 1)
            {
                canvasGroup.alpha += newValue;
            }
            else
            {
                canvasGroup.alpha = 1;
            }
            yield return null;
        }
    }
    private IEnumerator CastSpell (Spell spell)
    {
        if (!casting)
        {
            StartCoroutine("FadeIn");
            casting = true;
            castImage.color = spell.myColor;
            castTransoform.position = starPos;
            float timeLeft = Time.deltaTime;
            float rate = 1.0f / spell.myCastTime;
            float progress = 0.0f;

            while (progress <= 1.0)
            {
                castTransoform.position = Vector3.Lerp(starPos, endPos, progress);

                progress += rate * Time.deltaTime;

                timeLeft += Time.deltaTime;

                yield return null;
            }
            castTransoform.position = endPos;
            casting = false;
            StartCoroutine("FadeOut");
        }
    }
    IEnumerator ShootFrost()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetTrigger("Throw");
    }
    IEnumerator ShootFire()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
        animator.SetTrigger("Throw");
    }
}
