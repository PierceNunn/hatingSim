using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDependantHandler : MonoBehaviour
{
    [SerializeField] private int _availableDay;
    [SerializeField] private Enums.DayPhases _availableTime;
    [SerializeField] private bool _availableAtTime = true;
    [SerializeField] private GameObject[] _timeDependantEntities; //objects that are only available during the set time

    private void Update()
    {
        CheckIfAvailableNow();
    }

    void CheckIfAvailableNow()
    {
        if (PlayerPrefs.GetInt("currentDay", 0) == _availableDay && PlayerPrefs.GetInt("currentTime", 0) == (int)_availableTime)
        {
            //shows each attached object if date and time is right
            foreach (GameObject g in _timeDependantEntities)
            {
                if (g != null)
                    g.SetActive(_availableAtTime);
            }
                
        }
            
        else
        {
            //hides each attacted object if date/time isn't right
            foreach (GameObject g in _timeDependantEntities)
            {
                if (g != null)
                    g.SetActive(!_availableAtTime);
            }
                
        }
    }
}
