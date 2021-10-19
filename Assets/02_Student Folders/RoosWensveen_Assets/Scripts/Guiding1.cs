using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guiding1 : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;
    bool company = false; 

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      if(player.position.x - transform.position.x < 0.5 || company) {
      company = true;
      nav.SetDestination(player.position);
      }
    }
}
