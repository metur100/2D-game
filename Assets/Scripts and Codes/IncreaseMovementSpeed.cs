using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMovementSpeed : MonoBehaviour
{
    private PlayerMovementHolyKnight movementSpeed = new PlayerMovementHolyKnight();
    public float incraseMovementSpeed = 140f;
    public float speedOverTimeDuration = 3f;
    public float normalMoveSpeed = 70f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(IncreasedMovementSpeed());
        }
    }
    IEnumerator IncreasedMovementSpeed()
    {
        movementSpeed.normalMovementSpeed = incraseMovementSpeed;
        yield return new WaitForSeconds(speedOverTimeDuration);
        movementSpeed.normalMovementSpeed = normalMoveSpeed;
    }
}
