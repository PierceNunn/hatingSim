using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectibleItem : ScriptableObject
{
    [SerializeField] private string _itemID;
    [SerializeField] private Sprite _itemImage;
}
