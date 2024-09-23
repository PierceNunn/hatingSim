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
    [SerializeField] private bool _destroyOnInteract = true;

    override public void OnInteract()
    {
        Invoke("CollectItem", 0.1f);
    }

    public void CollectItem()
    {
        //flags item as found in PlayerPrefs
        //(0 is false and 1 is true due to PP not supporting bools)
        PlayerPrefs.SetInt(_itemData.ItemID, 1);
        print("item " + _itemData.ItemID + " collected");
        if (_destroyOnInteract)
            Destroy(gameObject);
    }
}
