using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Zombie : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;
    public NavMeshAgent agent;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    private Vector3 destinoAleatorio;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    public void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    ZombieController.playerDetected = true;
                    Debug.Log("I can see the player!");
                }
                else
                {
                    canSeePlayer = false;
                    ZombieController.playerDetected = false;
                }
            }
            else
            {
                canSeePlayer = false;
                ZombieController.playerDetected = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            ZombieController.playerDetected = false;
        }
    }

    public void AllChase()
    {
        if (ZombieController.playerTransform != null)
            agent.SetDestination(ZombieController.playerTransform.position);
    }
    public void Chase()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            ZombieController.playerTransform = target;

            if(ZombieController.playerTransform != null)
                agent.SetDestination(ZombieController.playerTransform.position);
        }
    }

    private void SetRandomDestination()
    {
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

    public void Wander()
    {
        if (!agent.hasPath || agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
    }
}
