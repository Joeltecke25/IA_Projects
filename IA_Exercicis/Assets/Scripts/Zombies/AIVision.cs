using UnityEngine;
using UnityEngine.AI;

public class AIVision : MonoBehaviour
{
    public Camera frustum;
    public float radius;

    public GameObject playerRef;
    public NavMeshAgent agent;
    private Animator animator;

    private Vector3 destinoAleatorio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        BroadcastMessage("Chase");
        BroadcastMessage("Wander");
    }

    public void Vision()
    {
        Vector3 raycastOrigin = frustum.transform.position;
        float maxDistance = 30;
        float fovRad = frustum.fieldOfView * Mathf.Deg2Rad;

        for (float angle = -fovRad / 2; angle <= fovRad / 2; angle += 0.1f)
        {
            Vector3 raycastDirection = frustum.transform.forward;
            raycastDirection = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0) * raycastDirection;

            RaycastHit hit;
            if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, maxDistance))
            {
                Debug.DrawRay(raycastOrigin, raycastDirection * maxDistance, Color.red);

                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(raycastOrigin, raycastDirection * maxDistance, Color.green);
                    Chase();
                }
            }
        }
    }

    private void Chase()
    {
        if (ZombieController.playerTransform != null)
            agent.SetDestination(playerRef.transform.position);
        
    }
    private void SetRandomDestination()
    {
        animator.SetFloat("Speed", agent.speed);
        {
            Vector3 posicionAleatoria = UnityEngine.Random.insideUnitSphere * radius;
            posicionAleatoria += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(posicionAleatoria, out hit, radius, NavMesh.AllAreas);

            if (hit.hit)
            {
                destinoAleatorio = hit.position;
                agent.SetDestination(destinoAleatorio);
            }
        }
    }

    private void Wander()
    {
        if (!agent.hasPath || agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
    }

}