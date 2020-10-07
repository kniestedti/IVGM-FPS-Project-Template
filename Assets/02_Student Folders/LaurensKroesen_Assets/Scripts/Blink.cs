using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]
public class Blink : MonoBehaviour
{
    public Camera cam;
    public Transform playerTransform;
    public GameObject tp_checker;
    private GameObject instance;

    public float tp_distance = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("BLINK"))
        {
            if (instance == null)
            {
                // TODO: Remove no longer needed with new raycast implementation of teleporting.
                
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    Vector3 pos;
                    
                    if (Physics.Raycast(ray, out hit))
                    {
                        pos = hit.point;
                        Quaternion rot = new Quaternion(0, 0, 0, 0);
                        instance = Instantiate(tp_checker, pos, rot);
                    }
                    
                    //Vector3 pos = playerTransform.position + playerTransform.forward * tp_distance;
                    
            }
            else
            {
                TP_Checker v = (TP_Checker) instance.gameObject.GetComponent(typeof(TP_Checker));
            
                // TP to instance and destroy
                Vector3 pos = instance.transform.position;
            
                Destroy(instance);
                instance = null;
            
                if (v.colliding)
                    playerTransform.position = pos;
            }

            //Debug.DrawRay(playerTransform.position, playerTransform.TransformDirection(Vector3.forward) * 20, Color.yellow, 10f);
            
            //Debug.Log(playerTransform.position);
            //Debug.Log(playerTransform.forward * 20);


            //playerTransform.position += playerTransform.forward * 20;
        }
    }
}
