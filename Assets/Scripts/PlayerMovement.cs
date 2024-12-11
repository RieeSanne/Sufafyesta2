using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float stamina = 100f;
    public float staminaDrainRate = 20f;
    public float staminaRegenRate = 10f;
    public float gravity = -9.81f; // Gravity force
    public float rotationSpeed = 10f; // Speed of turning

    private CharacterController controller;
    private Animator animator; // Reference to the Animator
    private float currentSpeed;
    private bool isSprinting;
    private Vector3 velocity; // For gravity calculation
    private Vector3 moveDirection; // For movement direction
    public PigManager pm;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Get the Animator component
        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        HandleMovement();
        ManageStamina();
    }

    private void HandleMovement()
    {
        // Get input and invert forward/backward only
        float horizontal = Input.GetAxis("Horizontal"); // Normal A/D input
        float vertical = Input.GetAxis("Vertical");    // Inverted W/S input
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Update Animator's Speed parameter
        float speed = moveDirection.magnitude * (isSprinting ? sprintSpeed / walkSpeed : 1f);
        animator.SetFloat("Speed", speed);

        if (speed >= 0.1f)
        {
            // Rotate the character to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the character
            Vector3 movement = moveDirection * currentSpeed * Time.deltaTime;
            controller.Move(movement);
        }

        // Sprinting logic
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            isSprinting = true;
            currentSpeed = sprintSpeed;
            stamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            currentSpeed = walkSpeed;
        }

        // Apply gravity
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep player grounded
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void ManageStamina()
    {
        // Replenish stamina if not sprinting
        if (!isSprinting && stamina < 100f)
        {
            stamina += staminaRegenRate * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pig"))
        {
            pm.pigCount++;
        }
    }
}
