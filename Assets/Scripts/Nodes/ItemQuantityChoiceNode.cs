using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ItemQuantityChoiceNode : ItemChoiceNode {

    [SerializeField] private int _quantityNeeded;
    public override bool IsSelectable()
    {
        Debug.Log("ItemQuantityChoiceNode");
        int quantityOwned = 0;
        foreach(CollectibleItem c in RequiredItem)
        {
            if (CollectibleItem.IsItemCollected(c))
                quantityOwned++;
        }
        Debug.Log(quantityOwned);
        if (quantityOwned >= _quantityNeeded)
            return true;
        return false;
    }
}