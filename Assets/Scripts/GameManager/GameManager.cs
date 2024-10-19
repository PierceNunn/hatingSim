using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private Dictionary<CollectibleItem, bool> sessionCollectedItems;

    public Dictionary<CollectibleItem, bool> SessionCollectedItems { get => sessionCollectedItems; set => sessionCollectedItems = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

        DontDestroyOnLoad(this);
    }


    public void CollectUnsavedItem(CollectibleItem item, bool status = true)
    {
        SessionCollectedItems.Add(item, status);
    }

    public void SaveCollectedItems()
    {
        print("saving!");
        foreach(CollectibleItem item in SessionCollectedItems.Keys)
        {
            //flags item as found in PlayerPrefs
            //(0 is false and 1 is true due to PP not supporting bools)
            PlayerPrefs.SetInt(item.ItemID, SessionCollectedItems[item] ? 1 : 0);
            print("saved " + item.ItemID + " as " + SessionCollectedItems[item]);
        }

        //wipe sessionCollectedItems afterwards
        SessionCollectedItems = new Dictionary<CollectibleItem, bool>();

        print("saved!");
    }
}
