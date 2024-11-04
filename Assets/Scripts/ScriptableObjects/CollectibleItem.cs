using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectibleItem : ScriptableObject
{
    [SerializeField] private string _itemID; //ID to store data under in PlayerPrefs
    [SerializeField] private Sprite _itemImage; //image to represent item
    [TextArea(3, 10)] [SerializeField] private string _itemBio; //bio for diaryUI

    public string ItemID { get => _itemID; set => _itemID = value; }
    public Sprite ItemImage { get => _itemImage; set => _itemImage = value; }
    public string ItemBio { get => _itemBio; set => _itemBio = value; }

    //this could probably be made into a static function
    public void CollectItem(bool collect = true)
    {
        //CollectItem pushes the collected item to GameManager, NOT PlayerPrefs
        //This is to have greater control over saving
        //Fully saving items to PlayerPrefs is done within GameManager
        GameManager.instance.CollectUnsavedItem(this, collect);
        Debug.Log("item " + ItemID + " collected (not saved)");
        
    }
    public static bool IsItemCollected(CollectibleItem item)
    {
        try
        {
            //GameManager will only have data for an item if it's been collected
            //and the game hasn't been saved
            //thus, the try catch is required in case the referenced entry in
            //SessionCollectedItems doesn't exist
            return GameManager.instance.SessionCollectedItems[item];
        }
        catch
        {
            //The function for getting values from PlayerPrefs has a built-in
            //default value, thus it will never return null or an error
            return PlayerPrefs.GetInt(item.ItemID, 0) == 1 ? true : false;
        }
        
    }

}
