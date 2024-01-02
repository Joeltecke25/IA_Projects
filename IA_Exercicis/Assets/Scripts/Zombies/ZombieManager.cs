using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    public Transform target;  // El objeto que los zombies seguirán
    public float detectionRadius = 10f;  // Radio de detección de los zombies
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        DetectTarget();
    }

    private void DetectTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))  // Asegúrate de que el objeto es el objetivo correcto
            {
                SetTarget(collider.transform);
                break;
            }
        }
    }

    private void SetTarget(Transform newTarget)
    {
        animator.SetFloat("Speed", navMeshAgent.speed);
        target = newTarget;

        // Si estás utilizando el sistema de navegación de Unity (NavMeshAgent), puedes hacer algo como esto:
        
        if (navMeshAgent != null && target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
