using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] GameObject VictoryCanvas;

    [SerializeField] LevelLoader levelLoader;

    public float victoryDuration;

    bool finish = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            VictoryCanvas.SetActive(true);
            finish = true;
        }
    }

    private void Update()
    {
        if(finish)
        {
            victoryDuration -= Time.deltaTime;

            if (victoryDuration < 0)
            {
                levelLoader.PlayGame();
            }
        }
    }
}
