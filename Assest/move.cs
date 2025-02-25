/*
  Class:    move.cs
  Author:   Carlos Linares, Juan Naranjo
  Date:     December 11, 2024

  I, Carlos Linares, 000929500 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
  I, Juan Naranjo, 000895164 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/



using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class move : MonoBehaviour
{
    public float speed = 3f;

    /// <summary>
    /// Moves the pipe to the left at a constant speed and destroys it when it goes off-screen.
    /// </summary>
    void Update()
    {
        // Move the pipe leftward
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy pipe when off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

  

}
