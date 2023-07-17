using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeStock1Node : Node
{
    Bxes box1;
    Vector3 box1Pos;
    bot botRef;
    NavMeshAgent agent;

    public TakeStock1Node(Bxes box1, Vector3 box1Pos, bot botRef, NavMeshAgent agent)
    {
        this.box1 = box1;
        this.box1Pos = box1Pos;
        this.botRef = botRef;
        this.agent = agent;
    }



    public override NodeState Evaluate()
    {

        float distance = Vector3.Distance(box1Pos, agent.transform.position);

        if (distance > 2f)
        {
            agent.isStopped = false;
            agent.SetDestination(box1Pos);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            botRef.hasStock = false;
            box1.currentItems = box1.maxItems;
            return NodeState.SUCCESS;
        }
    }
}
