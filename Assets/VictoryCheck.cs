using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] GameObject VictoryCanvas;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] GameObject player;
    [SerializeField] int level;

    static int currentLevel;
    static bool playerJustFinished = false;

    public float victoryDuration;

    bool finish = false;

    private void Start()
    {
        playerJustFinished = false;

        if(level == 1)
        {
            currentLevel = 1;
        }
        else
        {
            currentLevel = 2;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            VictoryCanvas.SetActive(true);
            finish = true;
            player.SetActive(false);

            playerJustFinished = true;

            Debug.Log("Finished = " + DidPlayerFinished());
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

    static public bool DidPlayerFinished()
    {
        return playerJustFinished;        
    }

    static public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
