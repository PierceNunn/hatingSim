using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ItemChoiceNode : ChoiceNode
{
    [SerializeField] private string _requiredItem;

    public string RequiredItem { get => _requiredItem; set => _requiredItem = value; }
}
