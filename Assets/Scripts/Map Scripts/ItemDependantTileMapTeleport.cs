using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDependantTileMapTeleport : TileMapTeleport
{
    [SerializeField] private ItemsForDay[] _daysWithRequiredItems;
    public override bool IsUsable()
    {
        foreach(ItemsForDay day in _daysWithRequiredItems)
        {
            if(day.TargetDay == PlayerPrefs.GetInt("currentDay", 0) &&
                day.TargetPhase == (Enums.DayPhases)PlayerPrefs.GetInt("currentTime", 0))
            {
                foreach(CollectibleItem item in day.TargetItems)
                {
                    if (!CollectibleItem.IsItemCollected(item))
                        return false;
                }
            }
        }
        return base.IsUsable();
    }
}
