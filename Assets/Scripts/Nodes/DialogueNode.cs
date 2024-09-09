using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(304)]
public class DialogueNode : Node {
	[Output] [SerializeField] private Node _lastNode;
	[SerializeField] private SingleDialogue _dialogue;
	[Input] [SerializeField] private Node _nextNode;

	public Node NextNode;

    public Node LastNode { get => _lastNode; set => _lastNode = value; }
    public SingleDialogue Dialogue { get => _dialogue; set => _dialogue = value; }



    // Use this for initialization
    protected override void Init() {
		base.Init();
		NodePort nextPort = GetInputPort("_nextNode").Connection;
		if (nextPort != null)
		{
			NextNode = nextPort.node as Node;
		}
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "_lastNode") 
			return GetInputValue<Node>("thisNode", this);
		else return null; // Replace this
	}
}