using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLife : MonoBehaviour
{
    public GameObject lifeIncrease;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_Knight_Advanturer").transform;
    }

    public void Use()
    {
        Instantiate(lifeIncrease, player.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
