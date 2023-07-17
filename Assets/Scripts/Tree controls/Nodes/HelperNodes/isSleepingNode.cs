using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSleepingNode : Node
{
    bot bot;

    public isSleepingNode(bot bot)
    {
        this.bot = bot;
    }

    public override NodeState Evaluate()
    {
        return bot.sleeping ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
