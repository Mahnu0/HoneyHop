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

    public void Play()
    {
        SceneManager.LoadScene("LVL_Select", LoadSceneMode.Single);
    }

    public void Options()
    {
        // SceneManager.LoadScene("Menu_Options", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu_Main", LoadSceneMode.Single);
    }
}
