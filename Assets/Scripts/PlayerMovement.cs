using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 800f;
    public float sidewaysForce = 50f;

    // We marked this as "Fixed"Update because we
    // are usig it to mess with physics.
    void FixedUpdate()
    {
        // Add a forward force on the z-axis
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); 

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the player left by adding a force
            // of -500 on the x-axis
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move the player right by adding a force
            // of 500 on the x-axis
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
