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

    [SerializeField]
    private GameObject streaker;

    private Transform streakerTransformSpawnPos;

    private GameObject player;


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
        player = GameObject.Find("Player");
        streakerTransformSpawnPos = GameObject.Find("StreakerSpawnPos").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        int randomStreaker = Random.Range(1, 10);

        
        //If randomStreaker er 10, så skal den instantiate en streaker.
        //Streaker Z rotation vendes mod Player, og løber lige ud
        if (randomStreaker == 10)
        {
            Instantiate(streaker, streakerTransformSpawnPos.position + new Vector3(0, 7.5f, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            return;
        }

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
