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
        if (character.index == 0 && character2.index == 1 || character.index == 1 && character2.index == 0)
        {
            PlayerPrefs.SetInt("CharacterSelected", character.index);
            PlayerPrefs.SetInt("CharacterSelected2", character2.index);
            SceneManager.LoadScene("Knight vs. Ninja");
        }
        else if (character.index == 1 && character2.index == 2 || character.index == 2 && character2.index == 1)
        {
            PlayerPrefs.SetInt("CharacterSelected", character.index);
            PlayerPrefs.SetInt("CharacterSelected2", character2.index);
            SceneManager.LoadScene("Ninja vs. Hunter");
        }
        else if (character.index == 0 && character2.index == 2 || character.index == 2 && character2.index == 0)
        {
            PlayerPrefs.SetInt("CharacterSelected", character.index);
            PlayerPrefs.SetInt("CharacterSelected2", character2.index);
            SceneManager.LoadScene("Knight vs. Hunter");
        }
    }
}