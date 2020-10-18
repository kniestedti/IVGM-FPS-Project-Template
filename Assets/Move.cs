using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Move : MonoBehaviour
{
    public float speed = 5.0f;
    private Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = (Transform) GetComponent(typeof(Transform));
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = _transform.forward * (speed * Time.deltaTime);
    }
}
