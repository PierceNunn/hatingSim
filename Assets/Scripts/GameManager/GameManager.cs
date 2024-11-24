using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const double GAME_VERSION = 0.1001;

    public static GameManager instance;

    private Dictionary<CollectibleItem, bool> sessionCollectedItems = new Dictionary<CollectibleItem, bool>();

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
        try
        {
            SessionCollectedItems.Add(item, status);
        }
        catch
        {
            SessionCollectedItems.Remove(item);
            print("Item was already queued for saving, removing and readding");
            SessionCollectedItems.Add(item, status);
        }
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

        PlayerPrefs.SetFloat("saveGameVersion", (float)GameManager.GAME_VERSION);
        print("saved!");
    }

    public bool IsSaveFromCurrentVersion()
    {
        float saveVersion = PlayerPrefs.GetFloat("saveGameVersion", 0f);

        if((float)GAME_VERSION == saveVersion)
        {
            return true;
        }

        return false;
    }
}
