using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmCharacter : MonoBehaviour
{
    public CharacterSelection character = new CharacterSelection();
    public CharacterSelection2 character2 = new CharacterSelection2();

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", character.index);
        PlayerPrefs.SetInt("CharacterSelected2", character2.index);
        SceneManager.LoadScene("Main");
    }
}