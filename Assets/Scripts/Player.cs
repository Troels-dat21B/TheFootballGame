using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Region: Movement Variables
    //References
    [Header("References")]
    [Tooltip("The transform of the player model")]
    public Transform trans;
    [Tooltip("The transform of the player model")]
    public Transform modelTrans;
    public CharacterController characterController;

    [Header("Ball Placement")]
    [Tooltip("The transform where the ball will be placed when the player has it")]
    public Transform BallPlacement;

    public AudioSource audioSource;

    public Camera cam;

    //Movement
    [Header("Movement")]
    [Tooltip("Units moved pr. second at max speed")]
    public float moveSpeed = 35;    //Movement speed

    [Tooltip("Extra units moved pr. second when sprinting")]
    public float sprintSpeed = 8;    //Sprint speed

    [Tooltip("Time in seconds it takes to reach max speed")]
    public float timeToMaxSpeed = .26f;    //Acceleration time

    private float VelocityGainPerSecond { get { return moveSpeed / timeToMaxSpeed; } }    //Velocity gain per second

    [Tooltip("Time in seconds it takes to stop")]
    public float timeToLooseMaxSpeed = .2f;    //Deceleration time

    private float VelocityLossPerSecond { get { return moveSpeed / timeToLooseMaxSpeed; } }    //Velocity loss per second


    [Tooltip("Multiplier for momentum attempting to move in a direction opposite the current travelling direction")]
    public float reverseMomentumMultiplier = 2.2f;    //Momentum multiplier
    private Vector3 movementVelocity = Vector3.zero;    //Current movement velocity

    //Region: Death and Respawning Variables
    [Header("Death and Respawning")]
    [Tooltip("Time in seconds before respawning")]
    public float respawnTime = 2f;    //Time before respawning
    private bool dead = false;    //Is the player dead?
    private Vector3 spawnPoint;    //Spawn point
    private Quaternion spawnRotation;    //Spawn rotation

    //Dashing
    [Header("Dashing")]
    [Tooltip("Total number of units traveled when dashing")]
    public float dashDistance = 17f;

    [Tooltip("Time taken to perform a dash, in seconds")]
    public float dashTime = .26f;

    private bool IsDashing { get { return Time.time < dashBeginTime + dashTime; } }

    private Vector3 dashDirection;
    private float dashBeginTime = Mathf.NegativeInfinity;

    [Tooltip("Time in seconds before the player can dash again")]
    public float dashCooldown = 1.8f;

    private bool CanDash { get { return Time.time > dashBeginTime + dashCooldown + dashTime; } }


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = trans.position;
        spawnRotation = modelTrans.rotation;
        BallPlacement = GameObject.FindGameObjectWithTag("BallPlacement").transform;
        Debug.Log("Got loaded");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SpeedUp();


    }

    void FixedUpdate()
    {
        if (!BallPlacement)
        {
            Die();
        }
    }


    public void Die()
    {

        if (!dead)
        {
            dead = true;
            Invoke("Respawn", respawnTime);
            dashBeginTime = Mathf.NegativeInfinity;
            movementVelocity = Vector3.zero;
            enabled = false;
            characterController.enabled = false;
            modelTrans.gameObject.SetActive(false);
            audioSource.Play();

        }

    }

    public void Respawn()
    {
        dead = false;
        trans.position = spawnPoint;
        enabled = true;
        characterController.enabled = true;
        modelTrans.gameObject.SetActive(true);
        modelTrans.rotation = spawnRotation;

    }

    //Region: Movement
    private void Movement()
    {
        if (!IsDashing)
        {
            //if W or the up arrow is held down
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {

                if (movementVelocity.z >= 0) //if the player is moving forward
                {
                    //increase Z velocity by velocity gain per second, but dont go higher then 'moveSpeed'
                    movementVelocity.z = Mathf.Min(movementVelocity.z + VelocityGainPerSecond * Time.deltaTime, moveSpeed);
                }
                else
                {
                    //if the player is moving backwards, increase Z velocity by velocity gain per second * reverse momentum multiplier, but dont go higher than 0
                    movementVelocity.z = Mathf.Min(movementVelocity.z + VelocityGainPerSecond * Time.deltaTime * reverseMomentumMultiplier, 0);
                }

            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            { //if S or the down arrow is held down

                if (movementVelocity.z > 0) //if the player is already moving forward
                {
                    //decrease Z velocity by velocity loss per second, but dont go lower then 0
                    movementVelocity.z = Mathf.Max(movementVelocity.z - VelocityLossPerSecond * Time.deltaTime * reverseMomentumMultiplier, 0);
                }
                else
                {
                    //if the player is moving backwards, or not moving at all
                    movementVelocity.z = Mathf.Max(movementVelocity.z - VelocityLossPerSecond * Time.deltaTime, -moveSpeed);
                }

            }
            else
            { //If neither forward or backwards is held
                if (movementVelocity.z > 0)
                { //if the player is moving forward
                  //decrease Z velocity by velocity loss per second, but dont go lower then 0
                    movementVelocity.z = Mathf.Max(movementVelocity.z - VelocityLossPerSecond * Time.deltaTime, 0);
                }
                else if (movementVelocity.z < 0)
                { //if the player is moving backwards
                  //increase Z velocity by velocity loss per second, but dont go higher then 0
                    movementVelocity.z = Mathf.Min(movementVelocity.z + VelocityLossPerSecond * Time.deltaTime, 0);
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //if D or the right arrow is held down
            {

                if (movementVelocity.x >= 0) //if the player is moving right
                {
                    //increase X velocity by velocity gain per second, but dont go higher then 'moveSpeed'
                    movementVelocity.x = Mathf.Min(movementVelocity.x + VelocityGainPerSecond * Time.deltaTime, moveSpeed);
                }
                else
                {
                    //if the player is moving left, increase X velocity by velocity gain per second * reverse momentum multiplier, but dont go higher than 0
                    movementVelocity.x = Mathf.Min(movementVelocity.x + VelocityGainPerSecond * Time.deltaTime * reverseMomentumMultiplier, 0);
                }

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            { //if A or the left arrow is held down

                if (movementVelocity.x > 0) //if the player is already moving right
                {
                    //decrease X velocity by velocity loss per second, but dont go lower then 0
                    movementVelocity.x = Mathf.Max(movementVelocity.x - VelocityLossPerSecond * Time.deltaTime * reverseMomentumMultiplier, 0);
                }
                else
                {
                    //if the player is moving left, or not moving at all
                    movementVelocity.x = Mathf.Max(movementVelocity.x - VelocityLossPerSecond * Time.deltaTime, -moveSpeed);
                }

            }
            else
            {

                if (movementVelocity.x > 0)
                { //if the player is moving right
                  //decrease X velocity by velocity loss per second, but dont go lower then 0
                    movementVelocity.x = Mathf.Max(movementVelocity.x - VelocityLossPerSecond * Time.deltaTime, 0);
                }
                else
                { //if the player is moving left
                  //increase X velocity by velocity loss per second, but dont go higher then 0
                    movementVelocity.x = Mathf.Min(movementVelocity.x + VelocityLossPerSecond * Time.deltaTime, 0);
                }
            }

            //If the player is moving in any direction
            if (movementVelocity.z != 0 || movementVelocity.x != 0)
            {

                characterController.Move(movementVelocity * Time.deltaTime);    //Move the player

                //Rotate the model to face the direction of movement with a smooth turn
                modelTrans.rotation = Quaternion.Slerp(modelTrans.rotation, Quaternion.LookRotation(movementVelocity), .18F);
            }
        }


    }


    private void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            moveSpeed = moveSpeed + sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            moveSpeed = moveSpeed - sprintSpeed;
        }
    }

    /// <summary>
    /// OnControllerColliderHit is called when the controller hits a
    /// collider while performing a Move.
    /// </summary>
    /// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ball")
        {
            hit.gameObject.GetComponent<Ball>().IsWithPlayer = true;
            //hit.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            hit.gameObject.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("Ball is with player");
            //hit.gameObject.transform.position = BallPlacement.position;
        }
    }
}
