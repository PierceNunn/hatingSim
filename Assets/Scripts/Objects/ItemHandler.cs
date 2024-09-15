using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private CollectibleItem _itemData;

    public void CollectItem()
    {
        PlayerPrefs.SetInt(_itemData.ItemID, 1);
    }
}
