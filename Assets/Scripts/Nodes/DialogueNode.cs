using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : Node {

	[SerializeField] private SingleDialogue[] _dialogue;
	[SerializeField] private DialogueResponse[] _responses;

	public SingleDialogue[] Dialogue { get => _dialogue; set => _dialogue = value; }
	public DialogueResponse[] Responses { get => _responses; set => _responses = value; }

	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}