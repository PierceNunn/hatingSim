using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsForDay
{
    [SerializeField] private int _targetDay;
    [SerializeField] private Enums.DayPhases _targetPhase;

    [SerializeField] private CollectibleItem[] _targetItems;

    public int TargetDay { get => _targetDay; set => _targetDay = value; }
    public Enums.DayPhases TargetPhase { get => _targetPhase; set => _targetPhase = value; }
    public CollectibleItem[] TargetItems { get => _targetItems; set => _targetItems = value; }
}
