using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_movement : MonoBehaviour
{
    public Transform target;
    public float t;
    public float speed; 

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);
    }
}
