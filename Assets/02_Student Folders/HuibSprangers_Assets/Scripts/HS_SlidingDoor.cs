using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_SlidingDoor : MonoBehaviour
{

    public float speed = 3f;

    bool isOpen = false;
    bool opening = false;
    float timer;
    float timerLength = 1f;

    public Transform door1;
    public Transform door2;

    Collider TriggerOpen;

    // Start is called before the first frame update
    void Start()
    {
        TriggerOpen = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(opening && timer > 0f)
        {
            door1.Translate(Vector3.forward * Time.deltaTime * speed);
            door2.Translate(-Vector3.forward * Time.deltaTime * speed);
            timer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!isOpen)
        {
            isOpen = true;
            timer = timerLength;
            opening = true;
        }
    }
}
