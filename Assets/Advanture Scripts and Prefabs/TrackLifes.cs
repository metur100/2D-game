using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackLifes : MonoBehaviour
{
    public static int scoreValue = 3;
    TextMeshProUGUI score;
    void Start()
    {
        scoreValue = 3;
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "= " + scoreValue;
    }
}
