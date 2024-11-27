using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text Counter;
    [SerializeField] TMP_Text Attemps;
    [SerializeField] Coins[] coins;


    void Update()
    {
        Counter.text = $"{Coins.count} / {Coins.maxCount}";

        Attemps.text = $"Attempt {Player.attemps}";

        
    }
}
