using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
    {
    public Vector3 offset;

    [Header("Put ball here")]
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position + offset;   
    }
}
