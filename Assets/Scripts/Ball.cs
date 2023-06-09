using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Set the force to apply when the ball is kicked
    public float kickForce;


    //Added by Troels
    public bool IsWithPlayer = false;

    [Tooltip("Delay on the collider being activated again after the ball is kicked")]
    public float delay = 0.15f;

    [Tooltip("The position where the ball is placed when it is with the player")]
    public Transform ballPlacement;


    void Awake()
    {
        ballPlacement = GameObject.Find("BallPlacement").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the isKinematic property to false so the ball is affected by physics
        GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (IsWithPlayer)
        {

            //Deaktiverer boldens collider når den er med spilleren
            gameObject.GetComponent<SphereCollider>().enabled = false;

            //To prevent the game from chrashing, when the player object gets destroyed
            if (!ballPlacement)
            {
                return;
            }
            else
            {
                transform.position = ballPlacement.position;

            }

            // Check if the space bar is pressed and kick the ball if it is
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Kick();
            }

        }


    }




    // Method for kicking the ball
    private void Kick()
    {
        //Added by Troels
        //Componenter der skal ændres når bolden sparkes
        IsWithPlayer = false;
        GetComponent<Rigidbody>().WakeUp();
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;

        //Til at give delay på metode kaldet
        Invoke("ActivateCollider", delay);

        // Calculate the movement direction based on the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Apply an impulse force in the movement direction to kick the ball
        GetComponent<Rigidbody>().AddForce(direction * kickForce, ForceMode.Impulse);



    }

    //Troels-
    //Metode til at aktivere boldens collider igen. Denne metode bliver kaldt med Invoke i Kick metoden
    //For at give et delay på 0.15 sekunder så spiller og bold ikke kolliderer med det samme igen
    void ActivateCollider()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
    }

}

