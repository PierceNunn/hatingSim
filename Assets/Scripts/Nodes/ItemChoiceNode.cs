using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

/*
 * ItemChoiceNode inherits from ChoiceNode and adds parameter for required item
 * if the required item is not flagged as obtained in save data, the choice
 * won't be accessible (most of which is processed in DialogueManager)
 */
public class ItemChoiceNode : ChoiceNode
{
    [SerializeField] private CollectibleItem[] _requiredItem;

    public CollectibleItem[] RequiredItem { get => _requiredItem; set => _requiredItem = value; }
}
