using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHealingPotion : MonoBehaviour
{
    public GameObject healthEffect;
    public int healing = 20;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_Knight_Advanturer").transform;
    }

    public void Use()
    {
        Instantiate(healthEffect, player.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
