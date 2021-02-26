using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoost : MonoBehaviour
{
    public PlayerMovementAdvanturerKnight boost;
    [SerializeField]
    private float boostTime = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Knight_Advanturer"))
        {
            PlayerMovementAdvanturerKnight boostSpeed = collision.gameObject.GetComponent<PlayerMovementAdvanturerKnight>();
            boostSpeed.normalMovementSpeed = 800f;
            StartCoroutine(WaitTime());
            boostSpeed.normalMovementSpeed = 400f;
        }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(boostTime);
    }
}
