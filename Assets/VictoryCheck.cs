using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] GameObject VictoryCanvas;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] GameObject player;
    [SerializeField] static int currentLevel;

    public float victoryDuration;

    bool finish = false;

    static public int[] finishLVL = new int[4];


    private void Start()
    {
        for(int i = 0; i < finishLVL.Length; i++)
        {
            finishLVL[i] = PlayerPrefs.GetInt("LVL" + i, 0);            
        }

        Debug.Log("FinishisEscene " + currentLevel + " = " + finishLVL[currentLevel]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            VictoryCanvas.SetActive(true);
            finish = true;
            player.SetActive(false);            

            finishLVL[currentLevel] = 1;

            PlayerPrefs.SetInt("LVL" + currentLevel, finishLVL[currentLevel]);

            Debug.Log("FinishisEscene " + currentLevel + " = " + finishLVL[currentLevel]);
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

    static public int IsLevelFinished()
    {
        return finishLVL[currentLevel];
    }
}
