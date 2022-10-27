using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Animator myDoorLeft = null;
    [SerializeField] private Animator myDoorRight = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string doorOpenLeft = "DoorOpen";
    [SerializeField] private string doorOpenRight = "DoorOpenRight";

    public Key script;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger && script.isKeyUnlocked)
            {
                myDoorLeft.Play(doorOpenLeft, 0, 0.0f);
                myDoorRight.Play(doorOpenRight, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
