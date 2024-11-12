using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TimeAdvanceNode : EndingNode {

    public override void OnCall()
    {
        base.OnCall();
        TimeUIManager.AdvanceTime();
    }

}