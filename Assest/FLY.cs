/*
  Class:    move.cs
  Author:   Carlos Linares, Juan Naranjo
  Date:     December 11, 2024

  I, Carlos Linares, 000929500 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
  I, Juan Naranjo, 000895164 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

using UnityEngine;

public class FLY : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;

    public AudioSource backSound;
    public AudioSource deathSound;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Background Music
        backSound = GetComponent<AudioSource>();
        if (deathSound == null)
        {
            deathSound = gameObject.AddComponent<AudioSource>();  // Add AudioSource if missing
        }
         
        deathSound.enabled = true;

    }
    /// <summary>
    /// Makes the bird flap when the player clicks the mouse or presses the spacebar.
    /// Resets the bird's vertical velocity and applies an upward force to simulate flapping.
    /// </summary>
    void Update()
    {
        // Flap when the player clicks or presses space
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a flap force to the bird (modify only vertical velocity)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);  // Reset vertical velocity
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);  // Apply upward force
        }
    }
    /// <summary>
    /// Handles the collision between the bird and pipes. When a collision occurs, the bird dies,
    /// a death sound is played, and the game is paused.
    /// </summary>
    /// <param name="collision">The collision details of the bird with another game object.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pipe"))
        {
            //Play death sound
            deathSound.Play();

            //Stop the game
            Time.timeScale = 0f;

            //Destroy the bird when collision
            Destroy(gameObject);
            Debug.Log("The bird died!");


            
        }

    }

}
