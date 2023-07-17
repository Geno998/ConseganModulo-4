using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class replenishShelf2Node : Node
{
    Bxes box2;
    Vector3 box2Pos;
    Vector3 shelf2Pos;
    bot botRef;
    NavMeshAgent agent;

    public replenishShelf2Node(Bxes box2, Vector3 box2Pos, Vector3 shelf2Pos, bot botRef, NavMeshAgent agent)
    {
        this.box2 = box2;
        this.box2Pos = box2Pos;
        this.shelf2Pos = shelf2Pos;
        this.botRef = botRef;
        this.agent = agent;
    }



    public override NodeState Evaluate()
    {
        float distance1 = Vector3.Distance(box2Pos, agent.transform.position);
        float distance2 = Vector3.Distance(shelf2Pos, agent.transform.position);
        Debug.Log("try to grt stock");

        if (!botRef.hasStock)
        {
            if (distance2 > 2f)
            {
                agent.isStopped = false;
                agent.SetDestination(shelf2Pos);
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
                agent.SetDestination(box2Pos);
                return NodeState.RUNNING;
            }
            else
            {
                agent.isStopped = true;
                botRef.hasStock = false;
                box2.currentItems = box2.maxItems + 1;
                return NodeState.SUCCESS;
            }
        }
    }
}
