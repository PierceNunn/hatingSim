using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

/* ItemQuantityChoiceNode is similar to ItemChoiceNode, with the main difference
 * being that ItemQuantityChoiceNode only requires some of the items in the
 * RequiredItem array rather than all of them. The quantity required is set by
 * _quantityNeeded, and it doesn't matter which items are owned, only how many.
 */
public class ItemQuantityChoiceNode : ItemChoiceNode {

    [SerializeField] private int _quantityNeeded;

    //overrides inherited IsSelectable function so it can be used in all
    //locations where ChoiceNode is referenced
    public override bool IsSelectable()
    {
        Debug.Log("ItemQuantityChoiceNode");

        int quantityOwned = 0;
        foreach(CollectibleItem c in RequiredItem)
        {
            if (CollectibleItem.IsItemCollected(c))
                quantityOwned++;
        }
        //return as selectable if owned quantity is greater or equal to what's needed
        if (quantityOwned >= _quantityNeeded)
            return true;
        return false;
    }
}