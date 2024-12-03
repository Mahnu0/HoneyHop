using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] TMP_Text Counter1;
    [SerializeField] TMP_Text Counter2;
    [SerializeField] int totalCoins1;
    [SerializeField] int totalCoins2;

    int count1 = 0;
    int count2 = 0;

    int maxCount1;
    int maxCount2;

    bool noMoreCoins = false;

    private void Start()
    {
        for(int i = 1; i < totalCoins1; i++)
        {
            if(PlayerPrefs.GetInt("Destroyed" + i + 1) != 0)
            {
                count1++;
            }
        }

        for (int i = 1; i < totalCoins2; i++)
        {
            if (PlayerPrefs.GetInt("Destroyed" + i + 2) != 0)
            {
                count2++;
            }
        }
    }

    void Update()
    {
        Counter1.text = $"{count1} / {maxCount1}";
        Counter2.text = $"{count2} / {maxCount2}";
    }
}
