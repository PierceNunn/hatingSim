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

    private float collectItemWaitTime = 0.1f;

    public void Start()
    {
        if (PlayerPrefs.GetInt(_itemData.ItemID, 0) == 1 && _destroyOnInteract)
            Destroy(gameObject);
    }
    override public void OnInteract()
    {
        StartCoroutine(CollectItem());
    }

    IEnumerator CollectItem()
    {
        yield return new WaitForSeconds(collectItemWaitTime);

        _itemData.CollectItem();
        if (_destroyOnInteract)
            Destroy(gameObject);
    }
}
