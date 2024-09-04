using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONConverter : MonoBehaviour
{
    [SerializeField] private BranchingDialogue _dialogueToConvert;
    void Start()
    {
        string json = JsonUtility.ToJson(_dialogueToConvert);
        print(json);
    }

}
