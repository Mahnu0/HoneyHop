using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Coins : MonoBehaviour
{
    static public int count;
    static public int maxCount;

    void Awake()
    {
        maxCount++;
        //transform.DORotate(new Vector3(0f, 45f, 0f), 1f, RotateMode.LocalAxisAdd).SetLoops(-1);
    }

    void OnTriggerEnter(Collider other)
    {
        count++;

        //GetComponent<Collider>().enable = false;

        //transform.DOMove();
        //transform.DORotate();
        //transform.DOScale().
        //    OnComplete(() => Destroy(gameObject));

        Destroy(gameObject);
    }

    //private void Start()
    //{
    //    transform.DORotate(Vector3.up * 360f, 1f).
    //        SetRelative().
    //        SetEase(Ease.Linear).
    //        SetLoops(-1);
    //}


    void OnDestroy()
    {
        Destroy(gameObject);
        //Destroy(transform);
    }
}
