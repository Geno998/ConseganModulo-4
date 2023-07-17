using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasItem1Node : Node
{
    bot bot;

    public hasItem1Node(bot bot)
    {
        this.bot = bot;
    }

    public override NodeState Evaluate()
    {
        return bot.hasItem1 ? NodeState.SUCCESS : NodeState.FAILURE;
    }

}
