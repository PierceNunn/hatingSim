using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleportLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] _mapTeleportLocationList;
    [SerializeField] private GameObject[] _insideLocationList;

    public GameObject[] MapTeleportLocationList { get => _mapTeleportLocationList; set => _mapTeleportLocationList = value; }
    public GameObject[] InsideLocationList { get => _insideLocationList; set => _insideLocationList = value; }
}
