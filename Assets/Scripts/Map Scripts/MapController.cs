using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject[] locations;

    private GameObject player;

    private PlayerMovement pM;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;

        pM = FindObjectOfType<PlayerMovement>();

    }


    public void Courtyard()
    {
        TeleportPlayer(0);
        pM.Map();
    }

    public void Library()
    {
        TeleportPlayer(1);
        pM.Map();
    }

    public void Gym()
    {
        TeleportPlayer(2);
        pM.Map();
    }

    public void Classroom()
    {
        TeleportPlayer(3);
        pM.Map();
    }

    public void Store()
    {
        TeleportPlayer(4);
        pM.Map();
    }

    public void Confrontation()
    {
        TeleportPlayer(5);
    }

    private void TeleportPlayer(int x)
    {
        player.transform.position = locations[x].transform.position;
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
