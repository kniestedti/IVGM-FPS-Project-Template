using UnityEngine;
using System.Collections;

public class ShootLollipop : MonoBehaviour {

    //public LollipopCounter ctr;

    public void OnMouseDown()
    {
        Destroy(gameObject);
        //ctr.counter--;
    }
}
