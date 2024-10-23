using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LVL1()
    {
        SceneManager.LoadScene("LVL_1", LoadSceneMode.Single);
    }

    public void LVL2()
    {
        SceneManager.LoadScene("LVL_2", LoadSceneMode.Single);
    }

    public void LVL3()
    {
        SceneManager.LoadScene("LVL_3", LoadSceneMode.Single);
    }
}
