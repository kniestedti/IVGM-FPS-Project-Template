using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCut1 : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject cookie;
    public GameObject explosion;
    public GameObject explosion2;
    public GameObject switchIn;
 
    private bool played = false;
    private bool paused = false;
    private Vector3 Pos ;
    public GameObject spot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            paused = true;
            playableDirector.Pause();
        }

        if (!played) {
            //float health = cookie.GetComponent<Health>().currentHealth;
            if (cookie == null)//cookie == null
            {
                switchIn.SetActive(true);
                //(cookie.GetComponent("EnemyController")).enabled = false;
                //cookie.GetComponent<EnemyController>().enabled = false;
                played = true;
                Debug.Log("D");
                playableDirector.Play();
                StartCoroutine(ExampleCoroutine());

            }
        }
        
    }
    IEnumerator ExampleCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds((float)6.5);
        //After we have waited 5 seconds 
        explosion.GetComponent<Exploder>().explosionTime = 1;
        explosion2.GetComponent<Exploder>().explosionTime = 1;
    }

}
