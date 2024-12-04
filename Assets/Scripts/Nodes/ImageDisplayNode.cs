using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ImageDisplayNode : DialogueNode {
	[SerializeField] private Sprite _imageToDisplay;
    [SerializeField] private bool _showImage = true;

    public Sprite ImageToDisplay { get => _imageToDisplay; set => _imageToDisplay = value; }

    public override void DialoguePlayBehavior()
    {
        FindObjectOfType<DialogueManager>().DisplayImage(_imageToDisplay, _showImage);
    }
}