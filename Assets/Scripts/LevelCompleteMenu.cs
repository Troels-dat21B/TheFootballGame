using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public GameObject levelCompleteMenuUI;

    private string currentLevelName;
    private LevelSelect levelSelect;

    void Awake()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        levelCompleteMenuUI.SetActive(false);
    }

    void Start()
    {
        levelSelect = FindObjectOfType<LevelSelect>();
    }


    public void LevelComplete()
    {
        Time.timeScale = 0f;
        levelCompleteMenuUI.SetActive(true);
    }

    public void NextLevel()
    {
        int currentLevel = int.Parse(currentLevelName.Substring(6));
        int nextLevel = currentLevel + 1;
        levelSelect.LevelComplete(currentLevel - 1);
        SceneManager.LoadScene("Level " + nextLevel);

    }

    public void LoadMenu()
    {
        int currentLevel = int.Parse(currentLevelName.Substring(6));
        int nextLevel = currentLevel + 1;
        levelSelect.LevelComplete(currentLevel - 1);
        levelCompleteMenuUI.SetActive(false);
        SceneManager.LoadScene("Level Selector");

    }
    public void QuitGame()
    {
        levelCompleteMenuUI.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
}
