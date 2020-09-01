using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    int characterIndex1; int characterIndex2;
    public void ChooseCharacter ()
    {
        PlayerPrefs.SetInt("SellectedCharacter", characterIndex1);
        PlayerPrefs.SetInt("SellectedCharacter2", characterIndex2);
    }
    public void LoadScene ()
    {
        SceneManager.LoadScene("Main");
    }
}
