using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Respawneador : MonoBehaviour
{
    public GameObject player;

    public void Respawn(float t)
    {
        player.SetActive(false);

        Player.attemps++;

        StartCoroutine(ActivatePlayer(t));
    }

    IEnumerator ActivatePlayer(float t)
    {
        player.SetActive(false);

        Physics.gravity = new Vector3(0, -45, 0);

        player.transform.rotation = quaternion.Euler(0, 0, 0);

        yield return new WaitForSeconds(t);

        player.transform.position = new Vector3(0, 1, 0);

        player.SetActive(true);
    }
}
