using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{   

    public GameObject TutorilaUI;
    public GameObject SettingsMenuUI;
    public GameObject MainMenuUI;
    
    void Start()
    {
        TutorilaUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

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

    public void Settings()
    {
        SettingsMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void Tutorial()
    {
        TutorilaUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void Back(){
        SettingsMenuUI.SetActive(false);
        TutorilaUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
