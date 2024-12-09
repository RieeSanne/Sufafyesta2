using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Animator animator; // Assign the Animator in the Inspector
    public float turnSpeed = 5f; // Adjust turning speed
    public float movementSpeed = 3f; // Adjust movement speed

    private Vector3 targetDirection;

    void Update()
    {
        // Example: Random movement or use NavMeshAgent for pathfinding
        targetDirection = GetTargetDirection(); // Implement this to get NPC's direction

        // Smoothly rotate the NPC towards the target direction
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        // Send movement data to Animator
        float turn = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up) / 180f;
        animator.SetFloat("Turn", turn); // -1 for left, 1 for right
        animator.SetFloat("Speed", movementSpeed); // Adjust speed based on movement
    }

    Vector3 GetTargetDirection()
    {
        // Example implementation, modify for your NPC logic
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return randomDirection.normalized;
    }
}
