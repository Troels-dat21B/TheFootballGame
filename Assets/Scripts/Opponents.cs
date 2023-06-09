using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Opponents : MonoBehaviour
{
    //Troels
    // Tutorial for this script: https://www.youtube.com/watch?v=4Wh22ynlLyk
    //Made changes to fit our needs
    public float moveSpeed = 30f;
    Rigidbody rb;

    Transform target;
    Vector3 direction;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
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


    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector3(direction.x, 0, direction.z) * moveSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ball is in the trigger");
            rb.isKinematic = false;

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
