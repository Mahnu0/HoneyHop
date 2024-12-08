using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text Attemps;


    void Update()
    {

        Attemps.text = $"Attempt {Player.attemps}";

        
    }
}
