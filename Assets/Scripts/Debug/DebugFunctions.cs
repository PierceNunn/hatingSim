using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugFunctions : MonoBehaviour
{

    public void ClearItemData()
    {
        CollectibleItem[] itemsToClear = 
        Resources.LoadAll<CollectibleItem>("Items");

        foreach(CollectibleItem c in itemsToClear)
        {
            PlayerPrefs.SetInt(c.ItemID, 0);
        }
    }
    public void GainAllItems()
    {
        CollectibleItem[] itemsToGain =
        Resources.LoadAll<CollectibleItem>("Items");

        foreach (CollectibleItem c in itemsToGain)
        {
            PlayerPrefs.SetInt(c.ItemID, 1);
        }
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
