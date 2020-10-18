using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzleChecker : MonoBehaviour
{
    public pillarPuzzle[] pillars = new pillarPuzzle[8];
    public GameObject reward;
    
    public void check()
    {
        int c = 0;
        foreach (var pillarPuzzle in pillars)
        {
            if (pillarPuzzle.active)
                c++;
        }

        if (c == 8)
        {
            Destroy(reward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
