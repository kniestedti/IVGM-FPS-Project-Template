using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class teleportDonut : MonoBehaviour {
    [Header("Parameters")]

    [Tooltip("Should the player be flipped when exiting the portal?")]
    public bool shouldFlip = false;

    [Tooltip("The other donut that you should exit from")]
    public GameObject exitDonut;

    private Collider m_Collider;
    private teleportDonut exitDonutScript;

    // Start is called before the first frame update
    void Start() {
        m_Collider = GetComponent<Collider>();
        DebugUtility.HandleErrorIfNullGetComponent<Collider, teleportDonut>(m_Collider, this, gameObject);

        m_Collider.isTrigger = true;
        exitDonutScript = exitDonut.GetComponent<teleportDonut>();
    }

    // Called every frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        PlayerCharacterController enteringPlayer = other.GetComponent<PlayerCharacterController>();

        if (enteringPlayer != null) {
            if (shouldFlip) {
                enteringPlayer.transform.Rotate(Vector3.up, 180f, Space.Self);
            }
            enteringPlayer.transform.position = exitDonut.transform.Find("Exit").gameObject.transform.position;
            Physics.SyncTransforms();
        }
    }
}