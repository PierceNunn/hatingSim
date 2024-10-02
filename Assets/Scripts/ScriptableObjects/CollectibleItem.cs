using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectibleItem : ScriptableObject
{
    [SerializeField] private string _itemID; //ID to store data under in PlayerPrefs
    [SerializeField] private Sprite _itemImage; //image to represent item
    [TextArea(3, 10)] [SerializeField] private string _itemBio;

    public string ItemID { get => _itemID; set => _itemID = value; }
    public Sprite ItemImage { get => _itemImage; set => _itemImage = value; }
    public string ItemBio { get => _itemBio; set => _itemBio = value; }

    public static bool IsItemCollected(CollectibleItem item)
    {
        return PlayerPrefs.GetInt(item.ItemID, 0) == 1 ? false : true;
    }
}
