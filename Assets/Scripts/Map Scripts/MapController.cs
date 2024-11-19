using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private TileMapTeleport[] _locations;
    [SerializeField] private GameObject _UIContents;
    [SerializeField] private Button[] _teleportButtons;

    private GameObject player;

    private PlayerMovement pM;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        pM = FindObjectOfType<PlayerMovement>();

        _locations = FindObjectOfType<MapTeleportLocations>().MapTeleportLocationList;

        UpdateTeleportButtons();

    }

    public void ToggleVisibility()
    {
        _UIContents.SetActive(!_UIContents.activeSelf);
        UpdateTeleportButtons();
    }

    public void UpdateTeleportButtons()
    {
        for(int i = 0; i < _locations.Length; i++)
        {
            _teleportButtons[i].interactable = _locations[i].IsUsable();
        }
    }

    public void TeleportPlayer(int x)
    {
        _locations[x].OnInteract();
    }

}
