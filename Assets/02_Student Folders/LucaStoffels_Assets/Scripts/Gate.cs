using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public float openDistance = 10;
    public GameObject Player;

    bool keyPickedUp = false;
    bool openingGate = false;

    public void Update()
    {
        if (keyPickedUp)
        {
            Vector3 positionDifference = Player.transform.position - transform.position;
            if (positionDifference.magnitude < openDistance)
            {
                openingGate = true;
            }
        }

        if (openingGate)
        {
            transform.position += new Vector3(0, 4 * Time.deltaTime, 0);
            if(transform.position.y >= 5.75) { Destroy(gameObject); }
        }
        
    }

    public void setKeyPickedUp(bool b)
    {
        keyPickedUp = b;
    }
}
