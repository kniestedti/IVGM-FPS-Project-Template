using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopCounter : MonoBehaviour
{
    public int counter ;

    // Start is called before the first frame update
    void Start()
    {
      GameObject[] npcs = GameObject.FindGameObjectsWithTag("Lollipop");
      counter = npcs.Length;
      Debug.Log(counter);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
       Debug.Log(counter);
    }
}
