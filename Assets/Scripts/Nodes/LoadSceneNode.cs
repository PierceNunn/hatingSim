using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XNode;

public class LoadSceneNode : EndingNode {
    [SerializeField] private string _sceneToLoad;

    public override void OnCall()
    {
        base.OnCall();
        SceneManager.LoadScene(_sceneToLoad);
    }
}