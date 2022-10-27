using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePhysics : MonoBehaviour
{
    PlayerCharacterController m_PlayerCharacterController;
    PlayerInputHandler m_InputHandler;

    bool slippy = false;
    float jumpMod = 0.0f;
    Vector3 prevSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    float originalMaxAir = 0.0f;

    void Start()
    {
        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, PlayerWeaponsManager>(m_PlayerCharacterController, this, gameObject);

        m_InputHandler = GetComponent<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerInputHandler, PlayerCharacterController>(m_InputHandler, this, gameObject);

        originalMaxAir = m_PlayerCharacterController.maxSpeedInAir;
    }

    void OnTriggerEnter(Collider collidor)
    {
        if (collidor.GetComponent<Collider>().name == "Ice")
        {
            slippy = true;
            jumpMod = 15.0f;
            m_PlayerCharacterController.maxSpeedInAir = originalMaxAir+jumpMod;
        }
    }

    void OnTriggerExit(Collider collidor)
    {
        if (collidor.GetComponent<Collider>().name == "Ice")
        {
            m_PlayerCharacterController.maxSpeedInAir = originalMaxAir+jumpMod;
            slippy = false;
        }
    }

    void Update()
    {

        Vector3 worldspaceMoveInput = transform.TransformVector(m_InputHandler.GetMoveInput());

        prevSpeed = prevSpeed * 0.71f;
        float maxSpeedOnGround = m_PlayerCharacterController.maxSpeedOnGround;
        if (m_PlayerCharacterController.isGrounded)
        {
            if (slippy)
            {
                jumpMod = 20.0f;
                float iceSpeed = 1.2f;
                // calculate the desired velocity from inputs, max speed, and current slope
                if (prevSpeed.x > maxSpeedOnGround * iceSpeed)
                {
                    prevSpeed.x = maxSpeedOnGround * iceSpeed;
                }
                else if (prevSpeed.x < -maxSpeedOnGround * iceSpeed)
                {
                    prevSpeed.x = -maxSpeedOnGround * iceSpeed;
                }
                if (prevSpeed.z > maxSpeedOnGround * iceSpeed)
                {
                    prevSpeed.z = maxSpeedOnGround * iceSpeed;
                }
                else if (prevSpeed.z < -maxSpeedOnGround * iceSpeed)
                {
                    prevSpeed.z = -maxSpeedOnGround * iceSpeed;
                }
                m_PlayerCharacterController.characterVelocity = m_PlayerCharacterController.characterVelocity * 0.6f + prevSpeed * 0.6f;
                prevSpeed = m_PlayerCharacterController.characterVelocity;
            }
            else
            {
                prevSpeed = m_PlayerCharacterController.characterVelocity;
                m_PlayerCharacterController.maxSpeedInAir = originalMaxAir;
                jumpMod = 0.0f;
            }
        }
        else
        {
            jumpMod = jumpMod * 0.98f;
        }
    }
}
