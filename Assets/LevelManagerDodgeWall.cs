using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerDodgeWall : MonoBehaviour
{
    public GameObject[] spikeWalls = new GameObject[4];
    public GameObject[] spawnpoints = new GameObject[8];
    public Boolean active = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            active = false;
            runSetPiece();
            
        }
    }

    void runSetPiece()
    {
        Instantiate(spikeWalls[0], spawnpoints[0].transform);
    }
}
