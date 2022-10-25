using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_RespawnBox : MonoBehaviour
{
    public GameObject toRespawnPrefab;
    public float timeToRespawn = 5f;
    float timer;
    bool respawning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(respawning){
            if(timer > 0){
                timer -= Time.deltaTime;
            } else {
                respawning = false;
                GameObject newInstance = Instantiate(toRespawnPrefab, transform.position, transform.rotation, transform);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        timer = timeToRespawn;
        respawning = true;
        other.transform.parent = null;
    }
}
