//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Core : MonoBehaviour
//{
//    Renderer rend;


//    // Start is called before the first frame update
//    void Start()
//    {
//        rend = GetComponentInParent<Renderer>();
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Killer"))
//        {
//            rend.enabled = false;
//            Player.SpeedX = 0;

//            StartCoroutine(WaitToRespawn());
//        }
//    }

//    IEnumerator WaitToRespawn()
//    {
//        yield return new WaitForSeconds(2);

//        transform.position = new Vector3(0, 1, 0);

//        rend.enabled = true;
//        Player.SpeedX = Player.initialSpeed;
//    }
//}
