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

    private void TeleportPlayer(int x)
    {
        player.transform.position = locations[x].transform.position;
        pM.Map();
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
