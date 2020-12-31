using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverAdvature : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void GameScene()
    {
        SceneManager.LoadScene("Advanture");
    }
    public void mainManuBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
