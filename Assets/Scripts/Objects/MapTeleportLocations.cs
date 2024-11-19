using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleportLocations : MonoBehaviour
{
    [SerializeField] private TileMapTeleport[] _mapTeleportLocationList;

    public TileMapTeleport[] MapTeleportLocationList { get => _mapTeleportLocationList; set => _mapTeleportLocationList = value; }
}
