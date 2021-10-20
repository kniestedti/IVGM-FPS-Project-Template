using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpen : MonoBehaviour
{
    
   // int number = 3;
    public float speed = 3f;
    bool isOpen = false;
    bool opening = false;
   // bool closing = false;
    float timer;
    float timerLength = 1f;

    
    Vector3 door1DefaultPos = new Vector3(0, 0, 0);
    Vector3 door2DefaultPos = new Vector3(0, 0, -3);
    Vector3 JumpPadWall1DefaultPos = new Vector3(-51, 18, -41);

    public Transform door1;
    public Transform door2;
    public Transform JumpPadWall1;

    Collider triggerZone;
    public AudioSource soundEffect;


    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>(); 
    }

    // Update is called once per frame
    public void DoorOpen()
    {
        // if (opening && timer > 0f)


        //  door1.Translate(Vector3.forward * Time.deltaTime * speed);
        //  door2.Translate(-Vector3.forward * Time.deltaTime * speed);
        if (door1.gameObject.activeSelf == true)
        {
            door1.gameObject.SetActive(false);
            door2.gameObject.SetActive(false);
        }
            //     timer -= Time.deltaTime;
        
        
        //if (closing && timer >0f)
        //{
        //    door1.Translate(-Vector3.forward * Time.deltaTime * speed);
        //    door2.Translate(Vector3.forward * Time.deltaTime * speed);
        //    timer -= Time.deltaTime;
        //} else if (closing && timer <= 0f)
        //{
        //    closing = false;
        //    timer = timerLength;
        //    isOpen = false;
        //    door1.localPosition = door1DefaultPos;
        //    door2.localPosition = door2DefaultPos;
        //}
    }

    public void JumpPadOpen()
    {
        //if (opening && timer > 0f)
        if (JumpPadWall1.gameObject.activeSelf == true)
        {
            JumpPadWall1.gameObject.SetActive(false);
        }
         //   timer -= Time.deltaTime;
        
    }

        void OnTriggerEnter (Collider other)
    {
        Damageable player = other.GetComponent<Damageable>();

        if (player == null) return;
        
        if (!isOpen)
        {
            isOpen = true;
            timer = timerLength;
            opening = true;
            soundEffect.Play();
        }
    }
}
