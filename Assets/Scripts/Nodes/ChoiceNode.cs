using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ChoiceNode : LinkedNode {
	[SerializeField] private string _choiceLabel;

    public string ChoiceLabel { get => _choiceLabel; set => _choiceLabel = value; }

    // Use this for initialization
    protected override void Init() {
		base.Init();
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this

	}
}