using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxFull1Node : Node
{
    Bxes box1;

    public boxFull1Node(Bxes box1)
    {
        this.box1 = box1;
    }

    public override NodeState Evaluate()
    {
        return box1.empty ? NodeState.SUCCESS : NodeState.FAILURE;
    }

}
