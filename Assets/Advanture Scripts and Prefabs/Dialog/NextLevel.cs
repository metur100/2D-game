using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Knight_Advanturer"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Advanture2");
        }
    }
}
