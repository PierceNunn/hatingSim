using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueBranchNode : Node {
	[Output] [SerializeField] private Node _lastNode;
	[Input(dynamicPortList = true)] [SerializeField] private Node[] _responses;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "_lastNode")
			return GetInputValue<Node>("_lastNode", this);
		return null; // Replace this
	}
}