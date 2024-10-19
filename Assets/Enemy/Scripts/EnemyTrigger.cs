using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    Vector3 initialPositionEnemy;

    void Start()
    {
        initialPositionEnemy = enemy.transform.position;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
        else if(other.gameObject == enemy)
        {
            enemy.SetActive(false);
            enemy.transform.position = initialPositionEnemy;
        }
    }
}
