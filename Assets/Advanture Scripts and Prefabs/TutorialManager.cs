using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject skipTutorial;
    public GameObject playGame;
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 0 || popUpIndex == 4
            || popUpIndex == 7 || popUpIndex == 8)
        {
            if (Input.anyKeyDown)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 9)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 10)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 11)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 12)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 13)
        {
            skipTutorial.SetActive(false);
            playGame.SetActive(true);
        }
    }
}
