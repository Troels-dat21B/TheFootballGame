using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameObject gameOverMenuUI;

    string currentSceneName;

    GameObject ball;
    GameObject player;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        ball = GameObject.FindWithTag("Ball");
        player = GameObject.Find("Player");
        gameOverMenuUI.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            Debug.Log("Could not find Player");
            GameOver();
        }
        if(!ball)
        {
            Debug.Log("Could not find Ball");
            GameOver();
        }

    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
        gameOverMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene("Level Selector");

    }
    public void QuitGame()
    {
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
}
