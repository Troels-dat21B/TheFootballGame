using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Set the force to apply when the ball is kicked
    public float kickForce = 100f;

    // Track whether the ball has been kicked or not
    private bool isKicked = false;

    //Added by Troels
    public bool IsWithPlayer = false;
    [Header("Ball Placement")]
    [Tooltip("The transform where the ball will be placed when the player has it")]
    public Transform BallPlacement;

    // Start is called before the first frame update
    void Start()
    {
        // Set the isKinematic property to false so the ball is affected by physics
        GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ball has been kicked and reset the flag if it has come to rest
        if (isKicked && GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
        {
            isKicked = false;
        }

        // Check if the space bar is pressed and kick the ball if it is
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kick();
        }
        FollowPlayer();
    }

    // Called when the player collides with the ball
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball has been kicked already and exit if it has
        if (isKicked) return;

        // Check if the collision was with the player and apply an impulse force if it was
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the movement direction based on the arrow keys
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            // Apply a force in the movement direction to dribble the ball
            GetComponent<Rigidbody>().AddForce(direction * 10f);

            // Rotate the ball to face the movement direction
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    // Method for kicking the ball
    private void Kick()
    {
        // Calculate the movement direction based on the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Apply an impulse force in the movement direction to kick the ball
        GetComponent<Rigidbody>().AddForce(direction * kickForce, ForceMode.Impulse);
        isKicked = true;
        
        //Added by Troels
        IsWithPlayer = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    //Added by Troels
    //Metode til at få bolden til at være foran spilleren
    private void FollowPlayer()
    {
        if (IsWithPlayer)
        {   
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = BallPlacement.position;
        }
    }


}

