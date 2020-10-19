using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTP : MonoBehaviour
{
    public GameObject level;
    public GameObject waypoint;
    public Transform playerTransform;
    public GameObject previous_level;
    
    public void activate()
    {
        level.SetActive(true);
        previous_level.SetActive(false);
        playerTransform.position = waypoint.transform.position;
        
    }
}
