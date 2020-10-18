using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTP : MonoBehaviour
{
    public GameObject level;
    public GameObject waypoint;
    public Transform playerTransform;
    
    public void activate()
    {
        level.SetActive(true);
        playerTransform.position = waypoint.transform.position;
    }
}
