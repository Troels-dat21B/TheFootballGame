using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameIsPaused){
            audioSource.Pause();
        }
        else{
            audioSource.UnPause();
        }
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
