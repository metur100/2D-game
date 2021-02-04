using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAOE : MonoBehaviour
{
    public GameObject preabAOE;
    public GameObject explosionEffect;
    public Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_Knight_Advanturer").transform;
    }

    public void Use()
    {
        Instantiate(preabAOE, player.transform.position, Quaternion.identity);
        Instantiate(explosionEffect, player.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}