using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int nextScene;
    public int levelSelector;
    public int level1;
    public int level2;
    public int level3;
    public int menu;

    float timer = 5;
    int currentScene;
    bool crossfade = false;

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 0 || currentScene == 1)
        {
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !crossfade)
            {
                crossfade = true;
            }
            if (timer <= 0 && !crossfade)
            {
                crossfade = true;
            }

            if (crossfade)
            {
                LoadNextLevel(nextScene);
            }
        }
        else if(currentScene == level1)
        {
            if (Input.GetKeyDown(KeyCode.P) && !crossfade)
            {
                LoadNextLevel(menu);
            }
        }
        else if (currentScene == level2)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !crossfade)
            {
                LoadNextLevel(menu);
            }
        }
    }

    public void PlayGame()
    {
        LoadNextLevel(levelSelector);
    }

    public void Level1()
    {
        LoadNextLevel(level1);
    }

    public void Level2()
    {
        LoadNextLevel(level2);
    }

    public void Level3()
    {
        LoadNextLevel(level3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel(int scene) // Scene number
    {
        StartCoroutine(LoadLevel(scene));
        crossfade = false;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
