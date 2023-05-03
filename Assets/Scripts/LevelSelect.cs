using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");

    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Troels Test");
    }
}
