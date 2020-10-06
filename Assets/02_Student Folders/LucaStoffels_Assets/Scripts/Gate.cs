using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public void openGate()
    {
        UnityEngine.Debug.Log("Open gate");
        Destroy(gameObject);
    }
}
