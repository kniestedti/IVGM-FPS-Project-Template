using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class TimerRespawner : MonoBehaviour
{
    public GameObject timerPickupPrefab;

    public int season = 0;

    public GameObject[] pickups;
    public Vector3[] positions;

    public void changeSeason(int seasonId)
    {
        season = seasonId;
    }

    void respawnTimers()
    {
        if (season == 0) // spring
        {
            respawn(0);
            respawn(1);
            respawn(2);
        }
        if (season == 1) // summer
        {
            respawn(0);
            respawn(1);
        }
        if (season == 2) // fall
        {
            respawn(0);
        }
        if (season == 3) // winter
        {
            respawn(3);
            respawn(4);
        }
    }

    void respawn(int timerId)
    {
        if (pickups[timerId] == null)
        {
           GameObject timerPickup = Instantiate(timerPickupPrefab, positions[timerId], transform.rotation);
           pickups[timerId] = timerPickup;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log(other.name);
        if(other.name == "Player")
        {
            respawnTimers();
        }
    }


}
