using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonPickup : MonoBehaviour
{
    [Header("Parameters")]
    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            Season season = go.GetComponent<Season>();
            if (season)
            {
                season.nextSeason();
            }
        }

        m_Pickup.PlayPickupFeedback();
        Destroy(gameObject);
    }
}
