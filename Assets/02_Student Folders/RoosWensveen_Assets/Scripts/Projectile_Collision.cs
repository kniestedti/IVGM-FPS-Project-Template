using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "lollipop") {
            Debug.Log("H");
            GetComponent<BreakFruit>().Run();
        }
    }
}
