using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] LevelButtons;
    bool[] LevelCompletionStatus = new bool[20];

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for (int i = 1; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].interactable = false;
        }
    }

    public void LevelComplete(int level)
    {
        LevelCompletionStatus[level] = true;
        if(level < LevelButtons.Length - 1)
        {
            LevelButtons[level + 1].interactable = true;
        }
    }

    
    
    public void LoadLevel(int level)
    {
        if(level > 0 && !LevelCompletionStatus[level - 1])
        {
            return;
        }

        SceneManager.LoadScene("Level " + (level + 1));
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");

    }

}
