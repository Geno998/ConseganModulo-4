using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class goToSleepNode : Node
{
    Vector3 nextToBed;
    Vector3 onTheBed;
    NavMeshAgent agent;
    bot botRef;
    Transform transform;

    public goToSleepNode(Vector3 nextToBed, Vector3 onTheBed, NavMeshAgent agent, bot botRef, Transform transform)
    {
        this.nextToBed = nextToBed;
        this.onTheBed = onTheBed;
        this.agent = agent;
        this.botRef = botRef;
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(nextToBed, agent.transform.position);

        if (!botRef.NearBed)
        {
            if (distance > 2f)
            {
                agent.isStopped = false;
                agent.SetDestination(nextToBed);
                return NodeState.RUNNING;
            }
            else
            {
                agent.isStopped = true;
                botRef.NearBed = true;
                return NodeState.RUNNING;
            }
        }
        else
        {
            transform.position = onTheBed;
            transform.eulerAngles = new Vector3(0, 0, 270);
            botRef.sleeping = true;
            return NodeState.SUCCESS;
        }





    }
}
