using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Coins : MonoBehaviour
{
    [SerializeField] int currentLevel;
    static public int count;
    static public int maxCount;
    bool haveBeenObtained;
    int destroyed;

    Vector3 initialPos;

    void Awake()
    {
        maxCount++;
        //transform.DORotate(new Vector3(0f, 45f, 0f), 1f, RotateMode.LocalAxisAdd).SetLoops(-1);
    }

    private void Start()
    {        
        if (PlayerPrefs.GetInt("firstTimePlaying", 0) == 0)
        {            
            PlayerPrefs.SetInt("firstTimePlaying", 1);
            PlayerPrefs.SetInt("Destroyed", 0);

            Debug.Log("FirstTimePlaying " + PlayerPrefs.GetInt("firstTimePlaying"));
        }

        if (PlayerPrefs.GetInt("Destroyed") == 1)
        {
            transform.position = new Vector3(0, -10, 0);
        }

        initialPos = transform.position;
        
    }

    void OnTriggerEnter(Collider other)
    {
        count++;

        //GetComponent<Collider>().enable = false;

        //transform.DOMove();
        //transform.DORotate();
        //transform.DOScale().
        //    OnComplete(() => Destroy(gameObject));
        haveBeenObtained = true;
        transform.position = new Vector3(initialPos.x, -10, initialPos.z);
    }

    private void Update()
    {
        if(VictoryCheck.IsLevelFinished() == currentLevel && haveBeenObtained)
        {
            PlayerPrefs.SetInt("Destroyed", 1);
        }
    }

    //private void OnDestroy()
    //{
    //    PlayerPrefs.SetInt("CoinsObtained");
    //}

    //private void Start()
    //{
    //    transform.DORotate(Vector3.up * 360f, 1f).
    //        SetRelative().
    //        SetEase(Ease.Linear).
    //        SetLoops(-1);
    //}
}
