using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDependantHandler : MonoBehaviour
{
    public enum DayPhases
    {
        morning,
        noon,
        evening
    }

    [SerializeField] private int _availableDay;
    [SerializeField] private DayPhases _availableTime;


}
