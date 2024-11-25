using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float stamina = 100f;
    public float staminaDrainRate = 20f;
    public float staminaRegenRate = 10f;
    public float gravity = -9.81f; // Gravity force

    private CharacterController controller;
    private float currentSpeed;
    private bool isSprinting;
    private Vector3 velocity; // For gravity calculation

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        HandleMovement();
        ManageStamina();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            controller.Move(move * currentSpeed * Time.deltaTime);
        }

        // Sprinting
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
}
