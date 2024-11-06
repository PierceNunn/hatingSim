using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDependants : TileMapTeleport
{
    [SerializeField] private CollectibleItem dependantItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CollectibleItem.IsItemCollected(dependantItem))
        {
            Teleport();
        }

    }
}
