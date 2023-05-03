using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void QuitGame()
    {        
        //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
        #endif
    
        //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
}
