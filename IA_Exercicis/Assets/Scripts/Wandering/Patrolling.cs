using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
    public Transform[] waypoints;
    private Animator animator;
    int waypointIndex;
    Vector3 target;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        animator.SetFloat("VelX", agent.speed);
        animator.SetFloat("VelY", agent.speed);
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        animator.SetFloat("VelX", agent.speed);
        animator.SetFloat("VelY", agent.speed);

        waypointIndex++;

        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
}
