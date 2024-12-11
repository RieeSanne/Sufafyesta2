using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public float maxSpeed = 5f; // Maximum movement speed for the character

    private void Awake()
    {
        // Automatically find the Animator component on the same GameObject
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement speed based on input
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        float speed = movement.magnitude;

        // Normalize and clamp speed
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", speed);
    }
}
