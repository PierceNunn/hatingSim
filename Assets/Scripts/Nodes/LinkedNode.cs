using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class LinkedNode : Node {
	[Output] [SerializeField] private Node _lastNode;
	[Input] [SerializeField] private Node _nextNode;

	private Node nextNode;

    public Node NextNode { get => nextNode; set => nextNode = value; }

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
		return null; // Replace this
	}
}