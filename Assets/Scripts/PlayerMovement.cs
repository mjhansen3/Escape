using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 800f;
    public float sidewaysForce = 50f;
    public float swipeSidewaysForce = 200f;
    public Swipe swipeControls;


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

        if (rb.position.y < -0.1f)
        {
            FindObjectOfType<GameManager>().EndGame();
            rb.AddForce(0, 0, 0 * Time.deltaTime);
            FindObjectOfType<AudioManager>().PlaySound("DeathSound");
            Destroy(gameObject);
        }

        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion

        // Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        // Did we cross deadzone?
        if (swipeDelta.magnitude > 35)
        {
            // which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                // Up or Down
                /*if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;*/
            }

            Reset();
        }

        if (swipeControls.SwipeLeft)
            rb.AddForce(-swipeSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (swipeControls.SwipeRight)
            rb.AddForce(swipeSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
