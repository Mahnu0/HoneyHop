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
    [SerializeField] AudioClip coin;

    int totalCoins;


    void Awake()
    {
        PlayerPrefs.SetInt("HaveBeenTaken" + id + currentLevel, 0);

        if (PlayerPrefs.GetInt("Destroyed" + id + currentLevel, 0) == 1)
        {
            count++;
        }

        maxCount++;
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("Destroyed" + id + currentLevel, 0) == 1)
        {
            transform.position = new Vector3(0, -10, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("HaveBeenTaken" + id + currentLevel, 1);
        SFXManager.instance.PlaySFX(coin, transform, 1f);
        transform.position = new Vector3(0, -10, 0);
    }

    private void Update()
    {
        if(VictoryCheck.DidPlayerFinished() == true &&
           currentLevel == VictoryCheck.GetCurrentLevel() &&
           PlayerPrefs.GetInt("HaveBeenTaken" + id + currentLevel, 0) == 1)
        {
            PlayerPrefs.SetInt("Destroyed" + id + currentLevel, 1);
        }
    }

}
