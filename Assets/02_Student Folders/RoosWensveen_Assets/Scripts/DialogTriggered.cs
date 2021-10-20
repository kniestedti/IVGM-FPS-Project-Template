using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggered : MonoBehaviour
{

//DialogText dt = new DialogText();
public DialogText dt;

public DialogText dialogtext;

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("hoi");
            //dt.O();
//dialogtext = GetComponent<DialogText>();
dialogtext.O();
        }
    }
}
