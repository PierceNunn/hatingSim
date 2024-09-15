using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Portrait
{
    //image associated with portrait
    [SerializeField] private Sprite _portraitImage;
    //id to find portrait from
    [SerializeField] private string _portraitID;
}
