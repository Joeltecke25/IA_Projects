using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIVision : MonoBehaviour
{
    public Camera frustum;
    public LayerMask mask;

    public float radius;

    public GameObject playerRef;
    public NavMeshAgent agent;
    private Animator animator;
    private Moves moves;

    private Vector3 destinoAleatorio;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        BroadcastMessage("Chase");
        BroadcastMessage("Wander");
    }

    public void Vision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(planes, col.bounds))
            {
                RaycastHit hit;
                Ray ray = new Ray();
                ray.origin = transform.position;
                ray.direction = (col.transform.position - transform.position).normalized;
                ray.origin = ray.GetPoint(frustum.nearClipPlane);

                if (Physics.Raycast(ray, out hit, frustum.farClipPlane, mask))
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        ZombieController.playerDetected = true;
                        ZombieController.playerTransform = hit.collider.transform;
                    }
                    else
                    {
                        ZombieController.playerDetected = false;
                    }
            }
            else
            {
                ZombieController.playerDetected = false;
            }
        }
    }

    private void Chase()
    {
        if (ZombieController.playerTransform != null)
        {
            Debug.Log("I have seen you!!");
            moves.Seek(playerRef.transform.position);
        }

    }
    private void SetRandomDestination()
    {
        //animator.SetFloat("Speed", agent.speed);
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
            moves.Wander();
        }
    }

}