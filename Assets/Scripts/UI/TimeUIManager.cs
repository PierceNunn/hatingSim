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
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void UpdateTimeUI()
    {

    }
}
