using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private List<Button> LevelButtons;
    bool[] LevelCompletionStatus = new bool[20];
    private Button[] buttons;
    public static LevelSelect Instance;

    private GameObject panelObject;

    string levelName = "Level Selector";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        panelObject = GameObject.Find("Panel");

    }



    void Start()
    {
        if (Instance)
        {

            SceneManager.sceneUnloaded += OnSceneUnloaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        if (SceneManager.GetActiveScene().name == levelName)
        {

            InitializeLevelButtons();
        }

    }

    void InitializeLevelButtons()
    {
        buttons = GameObject.FindObjectsOfType<Button>().OrderBy(go => go.name).ToArray();
        LevelButtons = new List<Button>();
        foreach (Button button in buttons)
        {
            if (button.name.Contains("Level"))
            {
                LevelButtons.Add(button);
            }
        }

        //Troels
        //ChatGPT metode til at sortere navnene, da CompareTo ikke kan sortere på white spaces og tal
        LevelButtons.Sort((a, b) =>
        {
            // Split the button names into an array of strings
            string[] xNameParts = a.gameObject.name.Split(' ');
            string[] yNameParts = b.gameObject.name.Split(' ');

            // Get the last part of the button names, which should be the number
            int xNumber = int.Parse(xNameParts[xNameParts.Length - 1]);
            int yNumber = int.Parse(yNameParts[yNameParts.Length - 1]);

            // Compare the numeric values of the numbers
            if (xNumber > yNumber)
            {
                return 1;
            }
            else if (xNumber < yNumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        });

        for (int i = 1; i < LevelButtons.Count; i++)
        {
            LevelButtons[i].interactable = false;
        }
    }
    public void LevelComplete(int level)
    {
        //Check if list is null or empty
        if (LevelButtons == null || LevelButtons.Count == 0)
        {
            return;
        }
        else
        {
            LevelCompletionStatus[level] = true;
            if (level < LevelButtons.Count - 1)
            {
                LevelButtons[level + 1].interactable = true;
            }
        }
    }



    public void LoadLevel(int level)
    {
        if (level > 0 && !LevelCompletionStatus[level - 1])
        {
            return;
        }

        SceneManager.LoadScene("Level " + (level + 1));
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");

    }

    public void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == levelName)
        {

            // Deactivate the panel when the UI object's scene is unloaded
            if (panelObject != null)
            {
                panelObject.SetActive(false);
            }
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == levelName)
        {
            // Activate the panel when the UI object's scene is loaded
            if (panelObject != null)
            {
                panelObject.SetActive(true);
            }
        }
    }

}