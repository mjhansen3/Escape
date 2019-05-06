using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;     // Reference to PlayerMovement script

    private shake shake;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }

    // Ths function runs when the player hits an obstacle
    // Information about the collision is collected and called "collisionInfo"
    void OnCollisionEnter (Collision collisionInfo)
    {
        // Check if object collided with has a tag called "Obstacle"
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false; // Player stops moving
            FindObjectOfType<GameManager>().EndGame();
            shake.CameraShake();
        }
    }
}
