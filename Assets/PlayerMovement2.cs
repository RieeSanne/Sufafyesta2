using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    // Movement speed
    public float moveSpeed = 5f;

    // Rigidbody component for physics-based movement
    private Rigidbody rb;

    // Movement input variables
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the player!");
        }
    }

    void Update()
    {
        // Get input from keyboard
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Calculate the movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}