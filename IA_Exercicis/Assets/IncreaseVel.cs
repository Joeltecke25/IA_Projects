using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using BBUnity.Actions;
using UnityEngine.AI;

[Action("MyActions/IncreaseVel")]
[Help("Increase the speed of a NavMesh Agent")]
public class IncreaseVel : GOAction
{
    [InParam("Speed")]
    [Help("speed")]
    public float speed;

    private UnityEngine.AI.NavMeshAgent agent;

    public override void OnStart()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = speed;
        base.OnStart();
    }
}
