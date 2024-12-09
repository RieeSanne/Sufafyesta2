using UnityEngine;
using UnityEngine.AI;

public class Pig : MonoBehaviour
{
    public int pigID; // Assign a unique ID for each pig in the Inspector
    private NavMeshAgent _agent;
    public GameObject Player;
    public float EnemyDistanceRun = 4.0f;
    public LayerMask wallLayer; // Assign the Wall layer in the Inspector
    private bool isAvoidingWall = false;

    public float normalSpeed = 3.5f; // Default movement speed
    public float chaseSpeed = 5.5f; // Speed when avoiding the player
    public float avoidWallSpeed = 2.0f; // Speed when avoiding walls

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = normalSpeed; // Set initial speed
    }

    void Update()
    {
        if (isAvoidingWall)
        {
            return; // Skip regular movement while avoiding walls
        }

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < EnemyDistanceRun)
        {
            _agent.speed = chaseSpeed; // Increase speed when moving away from the player
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            if (IsPathBlocked(newPos))
            {
                StartCoroutine(AvoidWall());
            }
            else
            {
                _agent.SetDestination(newPos); // Move away from the player
            }
        }
        else
        {
            _agent.speed = normalSpeed; // Return to normal speed
        }
    }

    private bool IsPathBlocked(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        float distance = direction.magnitude;

        return Physics.Raycast(transform.position, direction.normalized, distance, wallLayer);
    }

    private System.Collections.IEnumerator AvoidWall()
    {
        isAvoidingWall = true;
        _agent.speed = avoidWallSpeed; // Slow down when avoiding walls

        Vector3 reroutePos = FindAlternativePosition();
        _agent.SetDestination(reroutePos);

        // Wait until the NavMeshAgent reaches the new position or a short timeout
        float timer = 0f;
        while (timer < 2f && !_agent.isStopped && Vector3.Distance(transform.position, reroutePos) > 0.5f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _agent.speed = normalSpeed; // Reset to normal speed
        isAvoidingWall = false;
    }

    private Vector3 FindAlternativePosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * EnemyDistanceRun;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, EnemyDistanceRun, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position; // Fallback: stay in place
    }
}
