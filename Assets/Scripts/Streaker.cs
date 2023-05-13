using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streaker : MonoBehaviour
{

    public float moveSpeed = 60f;
    Rigidbody rb;

    Transform target;
    Vector3 direction;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

        }
    }
}
