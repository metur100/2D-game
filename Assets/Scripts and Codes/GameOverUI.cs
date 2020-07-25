using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Exit ()
    {
        Application.Quit();
    }
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void mainManuBack ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
