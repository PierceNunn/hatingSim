using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.SceneManagement;

public class TimeAdvanceNode : EndingNode {

    public override void OnCall()
    {
        base.OnCall();
        TimeUIManager.AdvanceTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}