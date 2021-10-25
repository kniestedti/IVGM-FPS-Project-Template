using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Range(10, 1000)]
    public float bounceHeight;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bouncer = collision.gameObject;
        Debug.Log(bouncer.name);
        PlayerCharacterController rb = bouncer.GetComponentInParent<PlayerCharacterController>();
        if (rb == null)
        {
            return; 
        }
        Debug.Log(rb.characterVelocity);
        // rb.characterVelocity+=(Vector3.up * bounceHeight);
        Vector3 velocity = rb.characterVelocity;
        velocity.y = bounceHeight;
        rb.characterVelocity = velocity;
        Debug.Log(rb.characterVelocity);
    }

}
