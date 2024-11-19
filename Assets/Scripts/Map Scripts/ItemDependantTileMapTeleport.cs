using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ItemDependantTileMapTeleport : TileMapTeleport
{
    [SerializeField] private ItemsForDay[] _daysWithRequiredItems;
    public override bool IsUsable()
    {
        //iterate through each day listed in daysWithRequiredItems
        foreach(ItemsForDay day in _daysWithRequiredItems)
        {
            //check if the day+time of array item match up with the current day+time
            if(day.TargetDay == PlayerPrefs.GetInt("currentDay", 0) &&
                day.TargetPhase == (Enums.DayPhases)PlayerPrefs.GetInt("currentTime", 0))
            {
                //if day+time lines up, iterate through all items listed for that day
                foreach(CollectibleItem item in day.TargetItems)
                {
                    //if a required item hasn't been collected, teleporter isn't usable
                    if (!CollectibleItem.IsItemCollected(item))
                    {
                        OpenUnusableTeleportDialogue(day.MissingItemsDialogue);
                        return false;
                    }
                        
                }
            }
        }
        //if false hasn't been called at this point the teleporter is usable
        return base.IsUsable();
    }

    private void OpenUnusableTeleportDialogue(IntroNode DialogueToGive)
    {
        try
        {
            FindObjectOfType<DialogueManager>().StartDialogue(DialogueToGive, gameObject, false);
        }
        catch
        {
            print("day conditional has no associated dialogue for when item(s) are missing.");
        }
        
    }
}
