using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    [SerializeField] Transform respawnPoint;
    void OnCollisionEnter(Collision col)
 {
     if(col.collider.CompareTag("Player"))
     {
         col.collider.GetComponent<Rigidbody>().position = respawnPoint.position;
     }
 }
}
