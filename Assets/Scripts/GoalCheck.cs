using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    public AudioSource Cheering;

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("GOOOOOOOAAAAAAAALLLLLLL!!!!!!!");
            Cheering.Play();
            Invoke("Goal", 2f);

        }
    }


    void Goal()
    {
        string levelName = SceneManager.GetActiveScene().name;

        int level = int.Parse(levelName.Substring(6)) - 1;
        SceneManager.LoadScene("Level Selector");

    }


}
