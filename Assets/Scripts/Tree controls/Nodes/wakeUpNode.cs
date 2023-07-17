using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class wakeUpNode : Node
{
    Vector3 NextToBed;
    Transform botTransform;
    bot botRef;

    public wakeUpNode(Vector3 nextToBed, Transform botTransform, bot botRef)
    {
        NextToBed = nextToBed;
        this.botTransform = botTransform;
        this.botRef = botRef;
    }

    public override NodeState Evaluate()
    {
        if(botRef.sleeping)
        {
            botTransform.position = NextToBed;
            botTransform.rotation = Quaternion.identity;
            botRef.sleeping = false;
            botRef.NearBed = false;
            return NodeState.RUNNING;
        }
        else
        {
            return NodeState.SUCCESS;
        }
    }
}
