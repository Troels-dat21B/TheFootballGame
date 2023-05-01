using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Set the force to apply when the ball is kicked
    public float kickForce = 100f;

    //Added by Troels
    public bool IsWithPlayer = false;

    [Tooltip("The position where the ball is placed when it is with the player")]
    public Transform ballPlacement;


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

            
            transform.position = ballPlacement.position;
            // Check if the space bar is pressed and kick the ball if it is
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Kick();
            }

        }
    }



    // Method for kicking the ball
    private void Kick()
    {
        //Added by Troels
        IsWithPlayer = false;
        GetComponent<Rigidbody>().WakeUp();
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        // Calculate the movement direction based on the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Apply an impulse force in the movement direction to kick the ball
        GetComponent<Rigidbody>().AddForce(direction * kickForce, ForceMode.Impulse);



    }



}

