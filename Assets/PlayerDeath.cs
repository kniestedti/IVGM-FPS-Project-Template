// Ground.cs: Kills players that touch this.collider.
using UnityEngine;
 
// Attach this to the grass collider
public class Ground : MonoBehaviour
{
 
  // Called when another collider hits the grass.
  // This is part of Unity!
  void OnCollisionEnter(Collision c)
  {
    // Does the other collider have the tag "Player"?
    if (c.gameObject.tag == "Player")
    {
      // Yes it does. Destroy the entire gameObject.
      Destroy(c.gameObject);
 
      // Find GameOver
      Kill Kill = FindObjectOfType<GameOver>();
      if (Kill == null)
                object Kill = Debug.LogWarning("Could not find GameOver!");
      else
        Kill.Canvas.enabled = true; // Show it
 
    }
  }
 
}