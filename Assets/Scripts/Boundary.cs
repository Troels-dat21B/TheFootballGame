using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{


    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Ball")
        {
            Destroy(other.gameObject);
        }
    }
}
