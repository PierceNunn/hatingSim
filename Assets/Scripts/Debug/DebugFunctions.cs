using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugFunctions : MonoBehaviour
{
    /// <summary>
    /// Sets all CollectibleItem objects as not found.
    /// </summary>
    public void ClearItemData()
    {
        //finds all CollectibleItems in Resources folder
        CollectibleItem[] itemsToClear = 
        Resources.LoadAll<CollectibleItem>("Items");

        foreach(CollectibleItem c in itemsToClear)
        {
            //using 0 as false and 1 as true as PP doesn't support bools
            PlayerPrefs.SetInt(c.ItemID, 0);
        }

        print("item data cleared successfully");
    }
    /// <summary>
    /// Sets all CollectibleItem objects as found.
    /// </summary>
    public void GainAllItems()
    {
        //finds all CollectibleItems in Resources folder
        CollectibleItem[] itemsToGain =
        Resources.LoadAll<CollectibleItem>("Items");

        foreach (CollectibleItem c in itemsToGain)
        {
            //using 0 as false and 1 as true as PP doesn't support bools
            PlayerPrefs.SetInt(c.ItemID, 1);
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

    public void AdvanceTime()
    {
        TimeUIManager.AdvanceTime();
    }
}
