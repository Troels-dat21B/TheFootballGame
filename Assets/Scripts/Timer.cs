using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



//This is taken from this link: https://forum.unity.com/threads/start-timer-on-new-scene.487709/

/* public class Timer : MonoBehaviour
{

    public TMP_Text timerText;
    float startTime;
    bool finished = false;
    string seconds;
    float t;

    void Awake()
    {
        timerText.text = "0";
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timerText.text = "0";
    }

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;

        t = Time.time + startTime;

        seconds = (t % 60).ToString("f2");

        timerText.text = seconds;
    }

    public void Finish()
    {
        if (t == 5.00f)
        {
            finished = true;
            timerText.color = Color.green;
        }
        else if (t > 5.00f)
        {
            finished = true;
            timerText.color = Color.red;
        }
        else if (t < 5.00f)
        {
            finished = true;
            timerText.color = Color.red;
        }
    }
} */
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    float startTime;
    bool finished = false;
    string seconds;
    float t;

    void Awake()
    {
        timerText.text = "0"; // set initial value to "0"
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;

        t = Time.time + startTime;

        seconds = (t % 60).ToString("f2");

        timerText.text = seconds;
    }

    public void Finish()
    {
        if (t == 5.00f)
        {
            finished = true;
            timerText.color = Color.green;
        }
        else if (t > 5.00f)
        {
            finished = true;
            timerText.color = Color.red;
        }
        else if (t < 5.00f)
        {
            finished = true;
            timerText.color = Color.red;
        }
    }
}

