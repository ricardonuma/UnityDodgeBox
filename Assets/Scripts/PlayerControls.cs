using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to switch scenes
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public string gameOverScene;

    private Rigidbody2D rb;
    private int boxSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // gets Left (A) or D (Right) keyboard press and multiply it by boxSpeed
        float horizontalDirection = Input.GetAxisRaw("Horizontal") * boxSpeed;

        // Set the velocity of the Box in the horizontal direction
        rb.velocity = new Vector2(horizontalDirection, rb.velocity.y);
    }

    // Called when the Box collides with anything
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if Box collides with Drop object
        if (col.gameObject.name == "Drop(Clone)")
        {
            // Load Game Over scene
            SceneManager.LoadScene(gameOverScene);
        }
    }
}
