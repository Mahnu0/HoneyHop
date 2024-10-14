using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawneador : MonoBehaviour
{
    public GameObject player;

    public void Respawn()
    {
        player.SetActive(false);

        StartCoroutine(ActivatePlayer());
    }

    IEnumerator ActivatePlayer()
    {
        player.SetActive(false);

        yield return new WaitForSeconds(2);

        player.transform.position = new Vector3(0, 1, 0);

        player.SetActive(true);
    }
}
