using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUIManager : MonoBehaviour
{
    


    [SerializeField] private TextMeshProUGUI _timeDisplay;

    private static int currentDay;
    private static Enums.DayPhases currentTime;
    
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
        if((int)currentTime + 1 >= Enum.GetNames(typeof(Enums.DayPhases)).Length)
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

        GameManager.instance.SaveCollectedItems();
        
    }

    public static void RestartTime()
    {
        PlayerPrefs.SetInt("currentDay", 0);
        PlayerPrefs.SetInt("currentTime", 0);
        currentDay = 0;
        currentTime = (Enums.DayPhases)0;
    }
    void UpdateTimeUI()
    {
        currentDay = PlayerPrefs.GetInt("currentDay", 0);
        currentTime = (Enums.DayPhases)PlayerPrefs.GetInt("currentTime", 0);
        _timeDisplay.text = "Day " + (currentDay + 1) + "\n(" + currentTime + ")";
    }
}
