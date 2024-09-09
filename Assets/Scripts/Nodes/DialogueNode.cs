using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : Node {
	[Output] [SerializeField] private Node node;
	[Input] [SerializeField] private string _responseName;
	[SerializeField] private SingleDialogue[] _dialogue;
	[Output(dynamicPortList = true)] [SerializeField] private Node[] _responses;


    // Use this for initialization
    protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "node") 
			return GetInputValue<Node>("node", this);
		return null; // Replace this
	}
}