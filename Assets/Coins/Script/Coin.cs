using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Coins : MonoBehaviour
{
    static public int count;
    static public int maxCount;
    [SerializeField] int currentLevel;
    [SerializeField] int id;

    int totalCoins;

    Vector3 initialPos;

    void Awake()
    {0
        count = 0;

        if(Player)

        maxCount++;
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("Destroyed" + id, 0) == 1)
        {
            transform.position = new Vector3(0, -10, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        count++;
        PlayerPrefs.SetInt("HaveBeenTaken" + id, 1);
        transform.position = new Vector3(0, -10, 0);
    }

    private void Update()
    {
        if(VictoryCheck.DidPlayerFinished() == true &&
           currentLevel == VictoryCheck.GetCurrentLevel() &&
           PlayerPrefs.GetInt("HaveBeenTaken" + id, 0) == 1)
        {
            PlayerPrefs.SetInt("Destroyed" + id, 1);
        }
    }

}
