using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSMovement : MonoBehaviour
{
    // Set the speed of the moving object and the radius of their movement
    public float speed = 1f;
    public float xRadius = 0f;
    public float yRadius = 0f;
    public float zRadius = 0f;

    // Saves the starting location of the object this script applies to
    float xStart;
    float yStart;
    float zStart;

    // The direction this object moves in, true is positive, false is negative
    bool xDir = true;
    bool yDir = true;
    bool zDir = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set the starting coordinates
        xStart = transform.position.x;
        yStart = transform.position.y;
        zStart = transform.position.z;
        // Randomly sets the direction to positive or negative
        if(Random.value < 0.5f) xDir = false;
        if(Random.value < 0.5f) yDir = false;
        if(Random.value < 0.5f) zDir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(xRadius > 0f){
            if(xDir){
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x - xRadius > xStart){
                    xDir = !xDir;
                }
            } else {
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
                if (transform.position.x + xRadius  < xStart){
                    xDir = !xDir;
                }
            }
        }

        if(yRadius > 0f){
            if(yDir){
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (transform.position.y - yRadius > yStart){
                    yDir = !yDir;
                }
            } else {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
                if (transform.position.y + yRadius  < yStart){
                    yDir = !yDir;
                }
            }
        }

        if(zRadius > 0f){
            if(zDir){
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (transform.position.z - zRadius >zStart){
                    zDir = !zDir;
                }
            } else {
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                if (transform.position.z + zRadius  < zStart){
                    zDir = !zDir;
                }
            }
        }
        
    }
}
