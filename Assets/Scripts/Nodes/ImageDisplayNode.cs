using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ImageDisplayNode : DialogueNode {
	[SerializeField] private Sprite _imageToDisplay;

    public Sprite ImageToDisplay { get => _imageToDisplay; set => _imageToDisplay = value; }

    public override void DialoguePlayBehavior()
    {

    }
}