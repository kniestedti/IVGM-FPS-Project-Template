using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(Pickup))]
public class Key : MonoBehaviour
{
    
    //Key is locked at start.
    [Header("Parameters")]
    [Tooltip("Whether the jetpack is unlocked at the begining or not")]
    public bool isKeyUnlocked = false;
    
    PlayerCharacterController m_PlayerCharacterController;
    PlayerInputHandler m_InputHandler;

    //public UnityAction<bool> onUnlockKey;

    void Start()
    {

        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, Key>(m_PlayerCharacterController, this, gameObject);

        m_InputHandler = GetComponent<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerInputHandler, Key>(m_InputHandler, this, gameObject);
    }
    
    public bool TryUnlock()
    {
        if (isKeyUnlocked)
            return false;

        //onUnlockKey.Invoke(true);
        isKeyUnlocked = true;
        return true;
    }
}
