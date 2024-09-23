using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUIManager : MonoBehaviour
{
    public enum DayPhases
    {
        morning,
        //noon,
        evening
    }


    [SerializeField] private TextMeshProUGUI _timeDisplay;

    private static int currentDay;
    private static DayPhases currentTime;
    
    void Start()
    {
        UpdateTimeUI();
    }

    private void Update()
    {
        UpdateTimeUI();
    }

    public static void AdvanceTime()
    {
        if((int)currentTime + 1 >= Enum.GetNames(typeof(DayPhases)).Length)
        {
            currentTime = 0;
            currentDay += 1;
        }
        else
        {
            currentTime += 1;
        }

        PlayerPrefs.SetInt("currentDay", currentDay);
        PlayerPrefs.SetInt("currentTime", (int)currentTime);
        
    }

    public static void RestartTime()
    {
        PlayerPrefs.SetInt("currentDay", 0);
        PlayerPrefs.SetInt("currentTime", 0);
        currentDay = 0;
        currentTime = (DayPhases)0;
    }
    void UpdateTimeUI()
    {
        currentDay = PlayerPrefs.GetInt("currentDay", 0);
        currentTime = (DayPhases)PlayerPrefs.GetInt("currentTime", 0);
        _timeDisplay.text = "Day " + currentDay + ", time " + currentTime;
    }
}
