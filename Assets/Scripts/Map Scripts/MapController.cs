using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject[] locations;
    [SerializeField] private GameObject _UIContents;

    private GameObject player;

    private PlayerMovement pM;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        pM = FindObjectOfType<PlayerMovement>();

        locations = FindObjectOfType<MapTeleportLocations>().MapTeleportLocationList;

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
        Vector3 newPlayerPos = new Vector3(locations[x].transform.position.x, locations[x].transform.position.y, player.transform.position.z);
        player.transform.position = newPlayerPos;
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

   // public void AdvanceTime()
   // {
    //    TimeUIManager.AdvanceTime();
    //    LoadScene(SceneManager.GetActiveScene().name);
    //}
}
