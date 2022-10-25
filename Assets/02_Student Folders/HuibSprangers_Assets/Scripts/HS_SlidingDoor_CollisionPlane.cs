using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_SlidingDoor_CollisionPlane : MonoBehaviour
{

    bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if(!activated && other.GetComponent<Health>() == null)
        {
            HS_SlidingDoor_Door Script = GetComponentInParent<HS_SlidingDoor_Door>();
            if(Script != null){
                Script.counter++;
            }
            activated = true;
        }
    }
}
