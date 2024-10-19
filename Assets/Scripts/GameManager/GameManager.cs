using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private Dictionary<CollectibleItem, bool> sessionCollectedItems;

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
        sessionCollectedItems.Add(item, status);
    }

    public void SaveCollectedItems()
    {
        print("saving!");
        foreach(CollectibleItem item in sessionCollectedItems.Keys)
        {
            //flags item as found in PlayerPrefs
            //(0 is false and 1 is true due to PP not supporting bools)
            PlayerPrefs.SetInt(item.ItemID, sessionCollectedItems[item] ? 1 : 0);
        }

        //wipe sessionCollectedItems afterwards
        sessionCollectedItems = new Dictionary<CollectibleItem, bool>();
    }
}
