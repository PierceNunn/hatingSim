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
}
