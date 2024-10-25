using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugFunctions : MonoBehaviour
{
    /// <summary>
    /// Sets all CollectibleItem objects as not found.
    /// </summary>
    public static void ClearItemData()
    {
        //finds all CollectibleItems in Resources folder
        CollectibleItem[] itemsToClear = 
        Resources.LoadAll<CollectibleItem>("Items");

        foreach(CollectibleItem c in itemsToClear)
        {
            //using 0 as false and 1 as true as PP doesn't support bools
            PlayerPrefs.SetInt(c.ItemID, 0);
            c.CollectItem(false);
        }

        print("item data cleared successfully");
    }
    /// <summary>
    /// Sets all CollectibleItem objects as found.
    /// </summary>
    public static void GainAllItems()
    {
        //finds all CollectibleItems in Resources folder
        CollectibleItem[] itemsToGain =
        Resources.LoadAll<CollectibleItem>("Items");

        foreach (CollectibleItem c in itemsToGain)
        {
            c.CollectItem();
        }

        print("hoarder mode enabled");
    }

    /// <summary>
    /// Reloads the currently loaded scene.
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        print("reloading! cover me!");
    }

    public static void AdvanceTime()
    {
        TimeUIManager.AdvanceTime();
    }

    public static void RestartTime()
    {
        TimeUIManager.RestartTime();
    }

    public static void SaveItems()
    {
        GameManager.instance.SaveCollectedItems();
    }
}
