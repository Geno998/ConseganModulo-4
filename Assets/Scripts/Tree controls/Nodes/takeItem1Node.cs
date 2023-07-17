using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class takeItem1Node : Node
{

    Bxes box1;
    Vector3 box1Pos;
    NavMeshAgent agent;
    bot botRef;

    public takeItem1Node(Bxes box1, Vector3 box1Pos, NavMeshAgent agent, bot botRef)
    {
        this.box1 = box1;
        this.box1Pos = box1Pos;
        this.agent = agent;
        this.botRef = botRef;
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
            botRef.hasItem1 = true;
            botRef.TakeItem1();
            return NodeState.SUCCESS;
        }

    }
}
