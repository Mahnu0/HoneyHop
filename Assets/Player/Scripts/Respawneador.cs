using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Respawneador : MonoBehaviour
{
    public float timeToRespawn = 0;
    [SerializeField] GameObject player;

    Player playerBee;

    float timer = 0;
    bool isRespawning = false;

    public void Respawn()
    {
        isRespawning = true;
    }

    private void Update()
    {
        if(isRespawning)
        {
            player.SetActive(false);            

            if (timer >= timeToRespawn)
            {
                player.SetActive(false);

                Physics.gravity = new Vector3(0, -45, 0);

                player.transform.rotation = quaternion.Euler(0, 0, 0);

                player.GetComponent<Rigidbody>().velocity = new Vector3(9, 0, 0);
                player.GetComponent<Rigidbody>().AddForce(0, 99, 0);

                player.transform.position = new Vector3(430f, 3f, 0);

                player.SetActive(true);

                timer = 0;

                isRespawning = false;

                Player.attemps++;
            }

            timer += Time.deltaTime;
        }        
    }
}
