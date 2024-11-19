using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleportLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] _mapTeleportLocationList;

    public GameObject[] MapTeleportLocationList { get => _mapTeleportLocationList; set => _mapTeleportLocationList = value; }
}
