using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guiding : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    public bool company = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if(player.position.x - transform.position.x < 0.5 || company) {
      company = true;
      transform.rotation = Quaternion.Euler(player.rotation.eulerAngles.x, player.rotation.eulerAngles.y, player.rotation.eulerAngles.z);
      transform.position = new Vector3(player.position.x-5, transform.position.y, player.position.z-5);
      }
    }
}
