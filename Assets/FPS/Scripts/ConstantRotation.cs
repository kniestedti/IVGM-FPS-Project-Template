using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{

    // [Tooltip("Rotation angle per second")]
    // public float rotatingSpeed = 360f;

    [Tooltip("Rotation speed in each axis (angles/sec)")]
    public Vector3 rotation = new Vector3(0,0,0);

    void Update()
    {
        // Handle rotating
        transform.Rotate(rotation.x * Time.deltaTime, rotation.y * Time.deltaTime, rotation.z * Time.deltaTime, Space.Self);
        Physics.SyncTransforms();
    }
}
