using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class replenishShelf1Node : Node
{
    Bxes box1;
    Vector3 box1Pos;
    Vector3 shelf1Pos;
    bot botRef;
    NavMeshAgent agent;

    public replenishShelf1Node(Bxes box1, Vector3 box1Pos, Vector3 shelf1Pos, bot botRef, NavMeshAgent agent)
    {
        this.box1 = box1;
        this.box1Pos = box1Pos;
        this.shelf1Pos = shelf1Pos;
        this.botRef = botRef;
        this.agent = agent;
    }



    public override NodeState Evaluate()
    {
        float distance1 = Vector3.Distance(box1Pos, agent.transform.position);
        float distance2 = Vector3.Distance(shelf1Pos, agent.transform.position);


        if (!botRef.hasStock)
        {
            if (distance2 > 2f)
            {
                agent.isStopped = false;
                agent.SetDestination(shelf1Pos);
                return NodeState.RUNNING;
            }
            else
            {
                agent.isStopped = true;
                botRef.hasStock = true;
                return NodeState.RUNNING;
            }
        }
        else
        {
            if (distance1 > 2f)
            {
                agent.isStopped = false;
                agent.SetDestination(box1Pos);
                return NodeState.RUNNING;
            }
            else
            {
                agent.isStopped = true;
                botRef.hasStock = false;
                box1.currentItems = box1.maxItems + 1;
                return NodeState.SUCCESS;
            }
        }

    }
}
