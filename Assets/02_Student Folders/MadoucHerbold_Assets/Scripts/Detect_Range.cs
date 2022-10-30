using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Range : MonoBehaviour
{
	private Transform player;
	private float dist;
	public float moveSpeed;
	public float howclose;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

	if(dist <= 0.5)
	{
	transform.LookAt(player);
	GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
	}
    }
}
