using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, KeyPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController byPlayer)
    {
        var key = byPlayer.GetComponent<Key>();
        if (!key)
            return;

        if (key.TryUnlock())
        {
            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        }
    }
}
