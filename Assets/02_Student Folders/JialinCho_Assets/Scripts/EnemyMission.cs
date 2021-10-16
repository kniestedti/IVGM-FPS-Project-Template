using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMission : MonoBehaviour
{
    List<GameObject> enemies1 = new List<GameObject>();
    List<GameObject> enemies2 = new List<GameObject>();

    public AutoOpen doorScript;

    void Start()
    {
        enemies1.AddRange(GameObject.FindGameObjectsWithTag("enemiesRoom1"));


        enemies2.AddRange(GameObject.FindGameObjectsWithTag("enemiesRoom2"));
    }

    void Update()
    {
        Debug.Log(enemies1.Count);
        for (int i = 0; i < enemies1.Count; i++)
        {
            if (enemies1[i] == null)
            {
                enemies1.Remove(enemies1[i]);
            }
        }
        if (enemies1.Count == 3)
        {
            doorScript.DoorOpen();
        }
    }
}
