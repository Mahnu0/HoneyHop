using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float timePlaying;

    void Start()
    {
        timePlaying = 0;
    }

    void Update()
    {
        timePlaying += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timePlaying / 60);
        int seconds = Mathf.FloorToInt(timePlaying % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
