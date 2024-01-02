using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

public class SeekMoves : MonoBehaviour
{
    private Moves moves;
    NavMeshAgent agent;

    void Start()
    {
        agent.SetDestination(moves.target.transform.position);
    }
}
