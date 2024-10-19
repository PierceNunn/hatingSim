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
}
