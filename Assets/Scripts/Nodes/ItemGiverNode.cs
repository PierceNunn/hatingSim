using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiverNode : DialogueNode
{
    [SerializeField] private CollectibleItem _itemToGive;
    [SerializeField] private bool _giveOrTakeItem = true;

    public CollectibleItem ItemToGive { get => _itemToGive; set => _itemToGive = value; }
    public bool GiveOrTakeItem { get => _giveOrTakeItem; set => _giveOrTakeItem = value; }

    public override void DialoguePlayBehavior()
    {
        base.DialoguePlayBehavior();
        ItemToGive.CollectItem(GiveOrTakeItem);
    }
}
