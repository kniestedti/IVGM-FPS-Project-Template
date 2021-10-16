using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class teleportDonut : MonoBehaviour
{
    [Header("Parameters")]

    [Tooltip("Destination object")]
    public GameObject target;

    Collider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        DebugUtility.HandleErrorIfNullGetComponent<Collider, teleportDonut>(m_Collider, this, gameObject);

        m_Collider.isTrigger = true;
        Debug.Log("Starting donut!");
    }

    // Called every frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Collision trigger");
        PlayerCharacterController enteringPlayer = other.GetComponent<PlayerCharacterController>();

        if (enteringPlayer != null)
        {
            Debug.Log("Found a player!");
            enteringPlayer.transform.position = target.transform.position;
            Physics.SyncTransforms();
        }
    }
}