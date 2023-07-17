using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class takeItem2Node : Node
{
    Bxes box2;
    Vector3 box2Pos;
    NavMeshAgent agent;
    bot botRef;

    public takeItem2Node(Bxes box2, Vector3 box2Pos, NavMeshAgent agent, bot botRef)
    {
        this.box2 = box2;
        this.box2Pos = box2Pos;
        this.agent = agent;
        this.botRef = botRef;
    }



    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(box2Pos, agent.transform.position);

        if (distance > 2f)
        {
            agent.isStopped = false;
            agent.SetDestination(box2Pos);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            botRef.hasItem2 = true;
            botRef.TakeItem2();
            return NodeState.SUCCESS;
        }

    }
}
