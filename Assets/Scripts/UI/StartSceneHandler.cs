using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DebugFunctions.ClearItemData();
        DebugFunctions.RestartTime();
    }

}
