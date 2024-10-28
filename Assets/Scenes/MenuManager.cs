using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    string nextScene;
    public void LVL1()
    {
        StartCoroutine(LoadLevel("LVL_1"));
    }

    public void LVL2()
    {
        StartCoroutine(LoadLevel("LVL_2"));
    }

    public void LVL3()
    {
        StartCoroutine(LoadLevel("LVL_3"));
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

    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
