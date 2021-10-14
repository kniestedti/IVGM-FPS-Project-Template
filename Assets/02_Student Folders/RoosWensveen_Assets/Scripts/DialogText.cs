using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject canvas;
    private int index;

    public Transform player;
    private Rigidbody rb;
    private bool beenDisplayed = false;

void Start() {
    canvas.gameObject.SetActive(false);
}
/*
    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("hoi");
            O();
        }
    }
*/

public void O() {
    canvas.gameObject.SetActive(true);
    textComponent.text = string.Empty;
    StartDialogue();

/*
    Debug.Log("hoiiiiiii");

    if(Input.anyKeyDown) 
    {
        if(textComponent.text == lines[index])
        {
            NextLine();
        }
        else 
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
*/
}

    // Update is called once per frame
   public void Update()
    {
        if(Input.anyKeyDown) 
        {
          if(textComponent.text == lines[index])
          {
            NextLine();
          }
          else 
          {
            StopAllCoroutines();
            textComponent.text = lines[index];
          }
        }
    }

    void StartDialogue()
    {
      index = 0;
      StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
      foreach (char c in lines[index].ToCharArray())
      {
        textComponent.text += c;
        yield return new WaitForSeconds(textSpeed);
      }
    }

    void NextLine()
    {
      if (index < lines.Length - 1)
      {
        index++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine()); 
      }
      else
      {
        gameObject.SetActive(false); 
      }
    }
}
