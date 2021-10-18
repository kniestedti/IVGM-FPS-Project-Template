using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class moveObjectOnDie : MonoBehaviour {

    [Tooltip("Object that should be moved")]
    public GameObject objectToMove;

    [Tooltip("Distance it should be moved relative to its original position")]
    public Vector3 distanceToMove;

    [Tooltip("String that should be displayed when the object is moved")]
    public string displayMessage;

    private NotificationHUDManager m_NotificationHUDManager;

    // Start is called before the first frame update
    void Start() {
        Health health = GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, moveObjectOnDie>(health, this, gameObject);

        health.onDie += OnDie;

        m_NotificationHUDManager = FindObjectOfType<NotificationHUDManager>();
        DebugUtility.HandleErrorIfNullFindObject<NotificationHUDManager, moveObjectOnDie>(m_NotificationHUDManager, this);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnDie() {
        Debug.Log("Moving object!");
        objectToMove.transform.position += distanceToMove;
        // Physics.SyncTransforms();
        m_NotificationHUDManager.CreateNotification(displayMessage);
    }
}
