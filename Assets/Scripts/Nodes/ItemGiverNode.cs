using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiverNode : DialogueNode
{
    [SerializeField] private CollectibleItem _itemToGive;

    public CollectibleItem ItemToGive { get => _itemToGive; set => _itemToGive = value; }
}
