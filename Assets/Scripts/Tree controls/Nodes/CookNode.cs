using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CookNode : Node
{
    Vector3 CoockPlace;
    NavMeshAgent agent;
    bot botRef;
    request requestRef;
    GameManager Gm;

    public CookNode(Vector3 coockPlace, NavMeshAgent agent, bot botRef, request requestRef, GameManager gm)
    {
        CoockPlace = coockPlace;
        this.agent = agent;
        this.botRef = botRef;
        this.requestRef = requestRef;
        Gm = gm;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(CoockPlace, agent.transform.position);

        if (distance > 2f)
        {
            agent.isStopped = false;
            agent.SetDestination(CoockPlace);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            requestRef.currentRecipeSO = requestRef.recipePull[Random.Range(0,requestRef.recipePull.Count)];
            botRef.hasItem1 = false;
            botRef.hasItem2 = false;
            Gm.Score += 1;
            return NodeState.SUCCESS;

        }

    }
}
