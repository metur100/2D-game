using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKnightPosition : MonoBehaviour
{
    private GameMaster gm;
    //public HealthKnightAdvanturer current;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastChackPointPos;
    }
    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector2 position;

        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }
}
