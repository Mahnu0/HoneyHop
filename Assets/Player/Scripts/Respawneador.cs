using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Respawneador : MonoBehaviour
{
    static float timer = 0;

    static public void Respawn(GameObject player, float t)
    {
        player.SetActive(false);

        Player.attemps++;

        if(timer >= t)
        {
            player.SetActive(false);

            Physics.gravity = new Vector3(0, -45, 0);

            player.transform.rotation = quaternion.Euler(0, 0, 0);

            player.GetComponent<Rigidbody>().velocity = new Vector3(9, 0, 0);

            player.transform.position = new Vector3(264.54f, 8.91f, 0);

            player.SetActive(true);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
