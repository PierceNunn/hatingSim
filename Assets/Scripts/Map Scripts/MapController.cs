using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject[] locations;
    //[SerializeField] private GameObject[] outdoorTeleports;
    //[SerializeField] private CollectibleItem[] dependantItems;
    [SerializeField] private GameObject _UIContents;

    private GameObject player;

    //private int currentDay;

    private PlayerMovement pM;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        pM = FindObjectOfType<PlayerMovement>();

        locations = FindObjectOfType<MapTeleportLocations>().MapTeleportLocationList;

        //NewDay();

        //LocationDependants();

    }

   // public void NewDay()
    //{
    //    currentDay = PlayerPrefs.GetInt("currentDay", 0);

    //    if (currentDay == 0)
     //   {
     //       outdoorTeleports = FindObjectOfType<MapTeleportLocations>().OutDoorTeleportersMars;
     //   }
      //  else if (currentDay == 1)
     //   {
      //      outdoorTeleports = FindObjectOfType<MapTeleportLocations>().OutDoorTeleportersEd;
     //   }
     //   else if (currentDay == 2)
     //   {
     //       outdoorTeleports = FindObjectOfType<MapTeleportLocations>().OutDoorTeleportersCourt;
      //  }
   // }

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

    //private void LocationDependants()
    //{
    //    for(int i = 0;  i < locations.Length; i++)
    //    {
    //        dependantItems[i] = outdoorTeleports[i].GetComponent<TileMapTeleport>().ReturnDependant();
    //    }
    //}



    //public void LocationUpdater()
    //{
    //    for (int i = 0; i < locations.Length; i++)
    //    {
     //       outdoorTeleports[i].SetActive(CollectibleItem.IsItemCollected(dependantItems[i]));
     //   }
   // }

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
