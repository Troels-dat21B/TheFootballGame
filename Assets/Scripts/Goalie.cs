using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Goalie : MonoBehaviour
{
    //Troels
    // Tutorial for this script: https://www.youtube.com/watch?v=4Wh22ynlLyk
    //Made changes to fit our needs
    public float moveSpeed = 5f;
    Rigidbody rb;

    Transform target;
    Vector3 direction;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ball").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float angle = MathF.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, angle, 0);
            direction = (target.position - transform.position).normalized;

        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector3(direction.x, 0, direction.z) * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            
        }
    }



}
