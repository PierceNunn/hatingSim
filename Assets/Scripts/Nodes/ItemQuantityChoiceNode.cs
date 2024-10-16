using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ItemQuantityChoiceNode : ItemChoiceNode {

    [SerializeField] private int _quantityNeeded;
    public override bool IsSelectable()
    {
        int quantityOwned = 0;
        foreach(CollectibleItem c in RequiredItem)
        {
            if (CollectibleItem.IsItemCollected(c))
                quantityOwned++;
        }
        if (quantityOwned >= _quantityNeeded)
            return true;
        return false;
    }
}