using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    public AudioSource Cheering;

    private Opponents[] opponents;

    private Goalie goalie;

    private LevelSelect levelSelect;

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        opponents = FindObjectsOfType<Opponents>();
        goalie = FindObjectOfType<Goalie>();
        levelSelect = FindObjectOfType<LevelSelect>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(goalie.gameObject);
            foreach (Opponents opponent in opponents)
            {
                Destroy(opponent.gameObject);
            }
            Debug.Log("GOOOOOOOAAAAAAAALLLLLLL!!!!!!!");
            Cheering.Play();
            Invoke("Goal", 2f);

        }
    }


    void Goal()
    {
        string levelName = SceneManager.GetActiveScene().name;

        int level = int.Parse(levelName.Substring(6)) - 1;

        levelSelect.LevelComplete(level);
        SceneManager.LoadScene("Level Selector");

    }


}
