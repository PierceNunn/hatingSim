﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(304)]
public class DialogueNode : LinkedNode {
	[SerializeField] private SingleDialogue _dialogue;

    public SingleDialogue Dialogue { get => _dialogue; set => _dialogue = value; }



    // Use this for initialization
    protected override void Init() {
		base.Init();
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "_lastNode") 
			return GetInputValue<Node>("thisNode", this);
		else return null; // Replace this
	}
}