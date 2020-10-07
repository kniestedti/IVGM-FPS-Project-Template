using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float deathHeight = -1;
    private bool set = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!set && transform.position.y < deathHeight)
        {
            transform.GetComponent<PlayerCharacterController>().gravityDownForce = 0;
            Vector3 v = transform.GetComponent<PlayerCharacterController>().characterVelocity;
            transform.GetComponent<PlayerCharacterController>().characterVelocity = new Vector3(v.x/5, -5, v.z/5);
            set = true;
        }
    }
}
