using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class GingerScript : MonoBehaviour
{
    public Transform Player;
    public Transform ginger;
    public float FollowDistance;
    float dist;

    public Animator animator;
    private NavMeshAgent agent;

    void Wake()
    {
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        dist = Vector3.Distance(Player.position, ginger.position);
        Debug.Log(dist);
        if (dist < FollowDistance)
        {
            //very close
            GetComponent<NavMeshAgent>().isStopped = true;
            animator.SetBool("Run", false);
        }
        else
        {
            //far away
            GetComponent<NavMeshAgent>().destination = Player.position;
            GetComponent<NavMeshAgent>().isStopped = false;
            animator.SetBool("Run", true);
        }

    }
}
