using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position + new Vector3(0.0f, 20.0f,-10.0f);   
    }
}
