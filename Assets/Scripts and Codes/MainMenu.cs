using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayAdvanture()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Advanture");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadAdvanture()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Advanture");
    }
}
