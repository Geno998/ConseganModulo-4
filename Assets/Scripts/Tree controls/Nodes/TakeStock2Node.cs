using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeStock2Node : Node
{
    Bxes box2;
    Vector3 box2Pos;
    bot botRef;
    NavMeshAgent agent;

    public TakeStock2Node(Bxes box2, Vector3 box2Pos, bot botRef, NavMeshAgent agent)
    {
        this.box2 = box2;
        this.box2Pos = box2Pos;
        this.botRef = botRef;
        this.agent = agent;
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
            botRef.hasStock = false;
            box2.currentItems = box2.maxItems;
            return NodeState.SUCCESS;
        }
    }
}
