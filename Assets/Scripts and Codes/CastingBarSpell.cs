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
    private Vector3 starPos;
    private Vector3 endPos;
    private Image castImage;
    private RectTransform castTransoform;
    private bool casting;
    public CanvasGroup canvasGroup;
    public float fadeSpeed;
    public Image frostBallAbility;
    public Image fireBallAbility;
    private float cooldownFrost = 2f;
    private float cooldownFire = 2f;
    bool isCooldownFrost = false;
    bool isCooldownFire = false;

    private Spell frostBall = new Spell("Frost Ball", 1f, Color.blue);
    private Spell fireBall = new Spell("Fire Ball", 1f, Color.red);
    // Start is called before the first frame update
    void Start()
    {
        frostBallAbility.fillAmount = 0;
        fireBallAbility.fillAmount = 0;
        casting = false;
        castTransoform = GetComponent<RectTransform>();
        castImage = GetComponent<Image>();

        endPos = castTransoform.position;
        starPos = new Vector3(castTransoform.position.x - castTransoform.rect.width, castTransoform.position.y, castTransoform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isCooldownFrost == false)
        {
            isCooldownFrost = true;
            frostBallAbility.fillAmount = 1;
            StartCoroutine(CastSpell(frostBall));
            StartCoroutine(ShootFrost());
            FindObjectOfType<AudioManager>().Play("CastingSpell");
        }
        if (Input.GetKeyDown(KeyCode.O) && isCooldownFire == false)
        {
            isCooldownFire = true;
            fireBallAbility.fillAmount = 1;
            StartCoroutine(CastSpell(fireBall));
            StartCoroutine(ShootFire());
            FindObjectOfType<AudioManager>().Play("CastingSpell");
        }
        if (isCooldownFrost)
        {
            frostBallAbility.fillAmount -= 1 / cooldownFrost * Time.deltaTime;
            if (frostBallAbility.fillAmount <= 0)
            {
                frostBallAbility.fillAmount = 0;
                isCooldownFrost = false;
            }
        }
        if (isCooldownFire)
        {
            fireBallAbility.fillAmount -= 1 / cooldownFire * Time.deltaTime;
            if (fireBallAbility.fillAmount <= 0)
            {
                fireBallAbility.fillAmount = 0;
                isCooldownFire = false;
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
        yield return new WaitForSeconds(1f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetTrigger("Throw");
    }
    IEnumerator ShootFire()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
        animator.SetTrigger("Throw");
    }
}
