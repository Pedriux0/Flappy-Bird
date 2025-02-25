/*
  Class:    move.cs
  Author:   Carlos Linares, Juan Naranjo
  Date:     December 11, 2024

  I, Carlos Linares, 000929500 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
  I, Juan Naranjo, 000895164 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject pipePrefab;      // The pipe prefab to spawn
    public float timeBetweenPipes = 2f; // Time between each pipe spawn
    public float pipeHeight = 5f;       // Height of the pipes
    public float pipeSpeed = 3f;        // Speed at which pipes move
    public float gapSize = 2.5f;        // Vertical gap between the top and bottom pipes

    private float timer;
    private float screenHeight;         // The height of the screen

    void Start()
    {
        // Get the screen height in world units
        screenHeight = Camera.main.orthographicSize * 2;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenPipes)
        {
            SpawnPipes();
            timer = 0f;
        }
    }
    /// <summary>
    /// Spawns two pipes (top and bottom) at a random vertical position on the screen.
    /// The pipes are assigned Rigidbody2D components and set to kinematic to avoid gravity.
    /// </summary>
    void SpawnPipes()
    {
        // Randomize the position of the gap for the pipes
        float randomY = Random.Range(-screenHeight / 2 + gapSize, screenHeight / 2 - gapSize);

        // Create the top pipe above the gap
        Vector3 topPipePosition = new Vector3(10f, randomY + gapSize / 2, 0f);
        // Create the bottom pipe below the gap
        Vector3 bottomPipePosition = new Vector3(10f, randomY - gapSize / 2, 0f);

        // Instantiate the pipes
        GameObject up = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);
        GameObject down = Instantiate(pipePrefab, bottomPipePosition, Quaternion.identity);

        // Assign the "pipe" tag to the instances
        up.tag = "pipe";
        down.tag = "pipe";

        // Ensure that each pipe has a Rigidbody2D for collision detection
        Rigidbody2D upRb = up.GetComponent<Rigidbody2D>();
        Rigidbody2D downRb = down.GetComponent<Rigidbody2D>();

        // If the pipes don't have Rigidbody2D, add them
        if (upRb == null) upRb = up.AddComponent<Rigidbody2D>();
        if (downRb == null) downRb = down.AddComponent<Rigidbody2D>();

        // Set the Rigidbody2D gravity scale to 0, as the pipes should not be affected by gravity
        upRb.gravityScale = 0f;
        downRb.gravityScale = 0f;

        // Use bodyType instead of isKinematic (as isKinematic is obsolete)
        upRb.bodyType = RigidbodyType2D.Kinematic;
        downRb.bodyType = RigidbodyType2D.Kinematic;

        // Verify the tags in the console (helpful for debugging if everything is set up correctly)
        Debug.Log("Top pipe tag: " + up.tag);
        Debug.Log("Bottom pipe tag: " + down.tag);
    }

}
