using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelLoader : MonoBehaviour
{
    public Animator[] transitions;
    public float transitionTime = 2f;
    public int nextScene;
    public int levelSelector;
    public int level1;
    public int level2;
    public int level3;
    public int menu;

    int previousScene;

    float timer = 5;
    int currentScene;
    bool crossfade = false;


    private void Start()
    {
        previousScene = PlayerPrefs.GetInt("previousScene", 0);
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0 || currentScene == 1)
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
                LoadNextLevel(nextScene, 1);
            }
        }
        else if(currentScene == level1)
        {
            if (Input.GetKeyDown(KeyCode.P) && !crossfade)
            {
                LoadNextLevel(menu, 1);
            }
        }
        else if (currentScene == level2)
        {
            if (Input.GetKeyDown(KeyCode.P) && !crossfade)
            {
                LoadNextLevel(menu, 1);
            }
        }
    }

    public void PlayGame()
    {
        LoadNextLevel(levelSelector, 1);
    }

    public void Level1()
    {
        Coins.maxCount = 0;
        LoadNextLevel(level1, 1);
    }

    public void Level2()
    {
        LoadNextLevel(level2, 1);
    }

    public void Level3()
    {
        LoadNextLevel(level3, 1);
    }

    public void Menu()
    {
        LoadNextLevel(menu, 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel(int scene, int t) // Scene number
    {
        SavePreviousScene();

        StartCoroutine(LoadLevel(scene, t));

        Coins.maxCount = 0;
        
        crossfade = false;
    }

    void SavePreviousScene()
    {
        PlayerPrefs.SetInt("previousScene", SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadLevel(int levelIndex, int t)
    {
        transitions[t].SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
