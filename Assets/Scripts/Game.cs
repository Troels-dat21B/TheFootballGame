using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField]
    private AudioSource Whistle;



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Time.timeScale = 1f;

        //Tjekker på om den aktive scene er Main Menu
        //Hvis den ikke er det, så skal den tilføje "Whistle" til Whistle klippet
        //Så den kun har lyden på levels
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            return;
        }
        else
        {
            List<AudioClip> clipsList = new List<AudioClip>();
            AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds");
            foreach (AudioClip clip in clips)
            {
                clipsList.Add(clip);
            }
            foreach (AudioClip clip in clipsList)
            {
                if (clip.name == "Whistle")
                {
                    Whistle.clip = clip;
                    
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        audioSource.Play();

        //Note til Niels, Fra Troels: Er det muligt at lave den samme logik på en "bedre" måde?
        if (Whistle == null)
        {
            return;
        }
        else
        {
            Whistle.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }
}
