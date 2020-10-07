using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Season))]

public class Snow : MonoBehaviour
{
    public void changeSeason(int seasonId)
    {
        if(seasonId == 3)
        {
            transform.GetComponent<Renderer>().enabled = true;
            transform.GetComponent<MeshCollider>().enabled = true;
        }
        else
        {
            transform.GetComponent<Renderer>().enabled = false;
            transform.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
