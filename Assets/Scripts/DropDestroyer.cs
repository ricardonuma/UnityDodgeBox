using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDestroyer : MonoBehaviour
{
    // Called when the WallBottom collides with anything
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if WallBottom collides with Drop object
        if (col.gameObject.name == "Drop(Clone)")
        {
            Debug.Log("Drop destroyed");
            // Destroy the Drop object
            Destroy(col.gameObject);
        }
    }
}
