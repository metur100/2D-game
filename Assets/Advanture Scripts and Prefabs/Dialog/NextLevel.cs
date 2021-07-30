using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public LevelLoader nextLevel;
    [SerializeField]
    private int buildLevelIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Knight_Advanturer"))
        {
            nextLevel.LoadScreenExample(buildLevelIndex);
        }
    }
}
