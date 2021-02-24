using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogLowerCave : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject activateDialog;
    public GameObject activatePortal;
    public PlayerMovementAdvanturerKnight moveSpeed;
    public GameObject continueButton;
    public GameObject activateTriggerCreatePlatform;

    private void Start()
    {
        StartCoroutine(Type());
    }
    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        //animator.SetTrigger("Change");
        continueButton.SetActive(false);
        activateTriggerCreatePlatform.SetActive(true);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            //Instantiate(triggerWall, transform.position, Quaternion.identity);
            StartCoroutine(Type());
            activatePortal.SetActive(true);
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
        if (index == sentences.Length - 1)
        {
            activateDialog.SetActive(false);
            moveSpeed.normalMovementSpeed = 400f;
        }
    }
}
