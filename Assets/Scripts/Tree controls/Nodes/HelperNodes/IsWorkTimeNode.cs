using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWorkTimeNode : Node
{
    private bot botRef;

    public IsWorkTimeNode(bot botRef)
    {
        this.botRef = botRef;
    }

    public override NodeState Evaluate()
    {
        return botRef.isWorkTime ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
