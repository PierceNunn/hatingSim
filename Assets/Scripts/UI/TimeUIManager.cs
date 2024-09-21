using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUIManager : MonoBehaviour
{
    public enum DayPhases
    {
        morning,
        noon,
        evening
    }


    [SerializeField] private TextMeshProUGUI _timeDisplay;

    private static int currentDay;
    private static DayPhases currentTime;
    
    void Start()
    {
        UpdateTimeUI();
    }

    void Update()
    {
        
    }

    void UpdateTimeUI()
    {
        currentDay = PlayerPrefs.GetInt("currentDay", 0);
        currentTime = (DayPhases)PlayerPrefs.GetInt("currentTime", 0);
        _timeDisplay.text = "Day " + currentDay + ", time " + currentTime;
    }
}
