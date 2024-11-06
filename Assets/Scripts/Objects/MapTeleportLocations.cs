using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleportLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] _mapTeleportLocationList;

    [SerializeField] private GameObject[] _outDoorTeleportersMars;
    [SerializeField] private GameObject[] _outDoorTeleportersEd;
    [SerializeField] private GameObject[] _outDoorTeleportersCourt;

    public GameObject[] MapTeleportLocationList { get => _mapTeleportLocationList; set => _mapTeleportLocationList = value; }

    public GameObject[] OutDoorTeleportersMars { get => _outDoorTeleportersMars; set => _outDoorTeleportersMars = value; }

    public GameObject[] OutDoorTeleportersEd { get => _outDoorTeleportersEd; set => _outDoorTeleportersEd = value; }

    public GameObject[] OutDoorTeleportersCourt { get => _outDoorTeleportersCourt; set => _outDoorTeleportersCourt = value; }
}
