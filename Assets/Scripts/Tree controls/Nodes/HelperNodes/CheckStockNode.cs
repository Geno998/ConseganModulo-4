using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStockNode : Node
{
    bot botRef;

    public CheckStockNode(bot botRef)
    {
        this.botRef = botRef;
    }

    public override NodeState Evaluate()
    {
        return botRef.hasStock ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
