using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Checker : MonoBehaviour
{
    public bool colliding = false;
    public MeshRenderer mesh;
    public Transform transform;
    public float rotation_speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        colliding = true;
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate( Vector3.up * (rotation_speed * Time.deltaTime));
        
        if (colliding)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
        
        
    }
}
