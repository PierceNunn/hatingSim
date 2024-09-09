using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueBranchNode : Node {
	[Output] [SerializeField] private Node _lastNode;
	[Input(dynamicPortList = true)] [SerializeField] private Node[] _responses;

	public Node[] nextNodes;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		nextNodes = new Node[_responses.Length];
		for(int i = 0; i < _responses.Length; i++)
        {
			NodePort nextPort = GetInputPort("_responses " + i).Connection;
			if (nextPort != null)
			{
				nextNodes[i] = nextPort.node as Node;
			}
		}
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "_lastNode")
			return GetInputValue<Node>("_lastNode", this);
		return null; // Replace this
	}
}