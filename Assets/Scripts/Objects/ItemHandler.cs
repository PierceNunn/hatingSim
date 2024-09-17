using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : InteractableEntity
{
    /*
     * ItemHandler is basically just an intermediary for the CollectibleItem
     * class as those are ScriptableObjects and as such cannot be put directly
     * into a scene
     */
    [SerializeField] private CollectibleItem _itemData;

    override public void OnInteract()
    {
        CollectItem();
    }

    public void CollectItem()
    {
        //flags item as found in PlayerPrefs
        //(0 is false and 1 is true due to PP not supporting bools)
        PlayerPrefs.SetInt(_itemData.ItemID, 1);
    }
}
