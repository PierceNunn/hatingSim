using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDependantHandler : MonoBehaviour
{
    [SerializeField] private int _availableDay;
    [SerializeField] private TimeUIManager.DayPhases _availableTime;
    [SerializeField] private GameObject[] _timeDependantEntities;

    private void Update()
    {
        CheckIfAvailableNow();
    }

    void CheckIfAvailableNow()
    {
        if (PlayerPrefs.GetInt("currentDay", 0) == _availableDay && PlayerPrefs.GetInt("currentTime", 0) == (int)_availableTime)
        {
            foreach (GameObject g in _timeDependantEntities)
                g.SetActive(true);
        }
            
        else
        {
            foreach (GameObject g in _timeDependantEntities)
                g.SetActive(false);
        }
    }
}
