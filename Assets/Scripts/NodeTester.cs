using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class NodeTester : MonoBehaviour
{
    [SerializeField] private DialogueNodeGraph _testGraph;
    void Start()
    {
        IntroNode testNode = _testGraph.findIntroNode();
        DialogueNode testDNode = testNode.NextNode as DialogueNode;
        print(testDNode.Dialogue.sentences);
        DialogueNode testDNodeTwo = testDNode.NextNode as DialogueNode;
        print(testDNodeTwo.Dialogue.sentences);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
