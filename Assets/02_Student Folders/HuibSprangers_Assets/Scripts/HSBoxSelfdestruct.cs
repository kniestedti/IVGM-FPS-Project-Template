using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSBoxSelfdestruct : MonoBehaviour
{
    [Tooltip("Height at which the object is destroyed instantly when falling off the map")]
    public float selfDestructYHeight = -20f; 

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < selfDestructYHeight)
        {
            Destroy(gameObject);
            return;
        }
    }
}
