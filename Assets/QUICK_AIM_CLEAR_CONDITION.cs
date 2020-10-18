using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUICK_AIM_CLEAR_CONDITION : MonoBehaviour
{
    public GameObject[] turrets = new GameObject[7];
    public GameObject next_level;

    public Boolean clear = false;
    
    // Update is called once per frame
    void Update()
    {
        if (!clear)
        {
            int c = 0;
            foreach (var turret in turrets)
            {
                if (turret == null)
                    c++;
            }

            if (c == 7)
            {
                Debug.Log("Level Clear!");
                clear = true;
                next_level.SetActive(true);
            }
        }
        
        
    }
}
