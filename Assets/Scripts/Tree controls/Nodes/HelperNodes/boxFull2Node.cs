using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class boxFull2Node : Node
{
    Bxes box2;

    public boxFull2Node(Bxes box2)
    {
        this.box2 = box2;
    }

    public override NodeState Evaluate()
    {
        return box2.empty ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
