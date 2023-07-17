using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasItem2Node : Node
{
    bot bot;

    public hasItem2Node(bot bot)
    {
        this.bot = bot;
    }

    public override NodeState Evaluate()
    {
        return bot.hasItem2 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
