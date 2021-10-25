using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CloudMovement : MonoBehaviour
{
   [Range(-1f, 1f)]
   public float horizontalSpeed;
 
    [Range(0, 5)]
    public float verticalSpeed;
 
    [Range(0, 2)]
    public float amplitude;
 
    public Vector3 originalPos;
 
    public Vector3 tempPosition;
 
 
    // Start is called before the first frame update
    void Start()
    {
        tempPosition = originalPos = transform.position;
 
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        tempPosition = originalPos;
        tempPosition.x += horizontalSpeed * Time.fixedDeltaTime;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
 
    }
}
