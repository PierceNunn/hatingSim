using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.SceneManagement;

public class TimeAdvanceNode : EndingNode {
    [SerializeField] private int _advanceTimeAmt = 1;
    public override void OnCall()
    {
        base.OnCall();
        TimeUIManager.AdvanceTime(_advanceTimeAmt);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}