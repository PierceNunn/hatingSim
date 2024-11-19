using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private TileMapTeleport[] _locations;
    [SerializeField] private GameObject _UIContents;

    private GameObject player;

    private PlayerMovement pM;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        pM = FindObjectOfType<PlayerMovement>();

        _locations = FindObjectOfType<MapTeleportLocations>().MapTeleportLocationList;

    }

    public void ToggleVisibility()
    {
        _UIContents.SetActive(!_UIContents.activeSelf);
    }


    public void Courtyard()
    {
        TeleportPlayer(0);
    }

    public void Library()
    {
        TeleportPlayer(1);
    }

    public void Gym()
    {
        TeleportPlayer(2);
    }

    public void Classroom()
    {
        TeleportPlayer(3);
    }

    public void Store()
    {
        TeleportPlayer(4);
    }

    public void Confrontation()
    {
        TeleportPlayer(5);
    }

    private void TeleportPlayer(int x)
    {
        _locations[x].OnInteract();
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
